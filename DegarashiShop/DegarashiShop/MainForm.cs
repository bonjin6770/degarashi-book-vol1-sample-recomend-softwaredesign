using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace DegarashiShop
{
    public partial class MainForm : Form
    {
        // カート(key = ID, value = count)
        Dictionary<int, int> _cart = new Dictionary<int, int>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void purchaseButton_Click(object sender, EventArgs e)
        {
            // 画面で選択した商品のリストを取得
            Dictionary<int, int> cart = _cart;

            // 購入できない商品リストの取得
            Dictionary<int, int> limitOverItems = GetLimitOverItems(cart);

            // 購入できない商品リストのメッセージ表示
            ShowMessageLimiteOverItems(limitOverItems);

            // 購入可能な商品を購入リストを取得
            Dictionary<int, int> purchaseItems = GetPurchaseItems(cart);

            // 購入する商品をデータベースへ保存
            SavePurchaseItems(purchaseItems);

            // 購入する商品への処理が完了したメッセージ表示
            ShowMessagePurchaseItems(purchaseItems);

        }

        private void ShowMessageLimiteOverItems(Dictionary<int, int> limitOverItems)
        {
            foreach (var id in limitOverItems)
            {
                string itemName = itemListBox.Items[id.Key - 1].ToString();

                string errorMessage = String.Format("商品一つにつき、ご購入できるのは１０個までです。{0}【{1}】は１０個以下にしてください。", System.Environment.NewLine, itemName);
                MessageBox.Show(errorMessage);
            }
        }

        private void SavePurchaseItems(Dictionary<int, int> purchaseItems)
        {

            // ２．データベースへの接続処理
            string dbfile = "degarashi-shop.db";
            using (var conn = new SQLiteConnection("Data Source=" + dbfile))
            {
                conn.Open();
                using (SQLiteTransaction sqlt = conn.BeginTransaction())
                {
                    using (SQLiteCommand command = conn.CreateCommand())
                    {
                        foreach (var id in purchaseItems)
                        {
                            string itemName = itemListBox.Items[id.Key - 1].ToString();
                            int itemCount = id.Value;

                            // ５．データベースへ購入情報の保存
                            command.CommandText = "insert into purchase (item_id) values('" + id.Key + "')";
                            command.ExecuteNonQuery();
                        }
                    }
                    sqlt.Commit();
                }
                conn.Close();
            }
        }

        private void ShowMessagePurchaseItems(Dictionary<int, int> purchaseItems)
        {
            // １．画面表示用の文言の準備
            var sb = new StringBuilder();
            sb.AppendLine("次の商品の購入処理を完了しました。");
            sb.AppendLine("===========================================");
            foreach (var id in purchaseItems)
            {
                string itemName = itemListBox.Items[id.Key - 1].ToString();
                int itemCount = id.Value;
                // ４．購入処理終了後、画面へ表示する文言の組み立て
                var selectedItem = String.Format("「{0} ({1}個)」", itemName, itemCount);
                sb.AppendLine(selectedItem);
            }
            MessageBox.Show(sb.ToString());
        }

        private Dictionary<int, int> GetPurchaseItems(Dictionary<int, int> cart)
        {
            Dictionary<int, int> purchaseItems = new Dictionary<int, int>();
            foreach (var item in cart)
            {
                int itemCount = item.Value;

                // ３．一つの商品を１０個以上購入することはできないので、そのチェック処理
                if (itemCount > 10)
                {
                    // 購入できない商品は飛ばす。
                    continue;
                }

                // 購入可能な商品を購入リストへ追加
                purchaseItems.Add(item.Key, item.Value);
            }

            return purchaseItems;
        }

        private Dictionary<int, int> GetLimitOverItems(Dictionary<int, int> cart)
        {
            Dictionary<int, int> limitOverItems = new Dictionary<int, int>();
            foreach (var item in cart)
            {
                int itemCount = item.Value;

                // ３．一つの商品を１０個以上購入することはできないので、そのチェック処理
                if (itemCount > 10)
                {
                    limitOverItems.Add(item.Key, item.Value);
                }
            }

            return limitOverItems;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // データベースから商品一覧を取得
            string dbfile = "degarashi-shop.db";
            using (var conn = new SQLiteConnection("Data Source=" + dbfile))
            {
                conn.Open();
                using (SQLiteCommand command = conn.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM items order by id";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            itemListBox.Items.Add(reader["name"].ToString());
                        }
                    }
                }
                conn.Close();
            }
        }

        private void addToCartButton_Click(object sender, EventArgs e)
        {
            // 購入処理
            var id = itemListBox.SelectedIndex + 1;

            if (_cart.ContainsKey(id))
            {
                // すでにカートに入っている種類の商品であれば終了を追加する
                _cart[id] = _cart[id] + 1;
            }
            else
            {
                // まだカートにない種類の商品であれば新規に追加する
                _cart.Add(id, 1);
            }

            // カートの中身を表示
            cartListBox.Items.Clear();
            foreach (var each in _cart)
            {
                var selectedItem = itemListBox.Items[each.Key - 1].ToString() + @" (" + each.Value.ToString() + @"個)";
                cartListBox.Items.Add(selectedItem);
            }
        }
    }
}
