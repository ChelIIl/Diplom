using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _123321123321111111111
{
    public partial class MainForm : Form
    {
        DB_LubimoiEntities2 db;

        double break_norm = 0;
        double din_norm = 0;
        double aft_norm = 0;

        public MainForm()
        {
            InitializeComponent();

            rec_din_kal_lbl.Text = din_norm.ToString();
            rec_break_kal_lbl.Text = break_norm.ToString();
            rec_aft_kal_lbl.Text = aft_norm.ToString();

            break_day_kal_lbl.Text = "450";
            din_day_kal_lbl.Text = "750";
            aft_day_kal_lbl.Text = "300";

            this.Fill();
        }

        private void add_dish_btn_Click(object sender, EventArgs e)
        {
            AddDishForm ad = new AddDishForm();
            ad.ShowDialog();

            this.Fill();
        }

        public void Fill()
        {
            all_dish_list.Items.Clear();

            List<Dish> li = DBConnection.Entities.Dishes.ToList();

            foreach (Dish d in li)
            {
                all_dish_list.Items.Add(d);
            }
            //all_dish_list.DataSource = DBConnection.Entities.Dishes.ToList();
            //all_dish_list.DisplayMember = "DishName";
            //all_dish_list.ValueMember = "DishId";
        }

        public void Fill(List<Dish> li)
        {
            all_dish_list.Items.Clear();

            foreach (Dish d in li)
            {
                all_dish_list.Items.Add(d);
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            List<Dish> li = DBConnection.Entities.Dishes.ToList();
            List<DishMealTime> li2 = DBConnection.Entities.DishMealTimes.ToList();
            List<DishMealTime> l2 = new List<DishMealTime>();
            List<Dish> l = new List<Dish>();

            if(choose_search_par_combox.Text == "Ккал")
            {
                foreach (Dish d in li)
                {
                    if (d.Calories <= Convert.ToDouble(search_txt.Text))
                        l.Add(d);
                }

                this.Fill(l);
            }

            else if(choose_search_par_combox.Text == "Названию")
            {
                foreach (Dish d in li)
                {
                    if (d.DishName == search_txt.Text)
                        l.Add(d);
                }

                this.Fill(l);
            }

            else if (choose_search_par_combox.Text == "Времени приема")
            {
                foreach (DishMealTime d in li2)
                {
                    if (d.MealTime == search_txt.Text)
                    {
                        foreach (Dish di in li)
                        {
                            if (di.DishId == d.DishId)
                                l.Add(di);
                        }
                    }
                }

                this.Fill(l);
            }
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            this.Fill();
        }

        private void del_dish_btn_Click(object sender, EventArgs e)
        {
            List<Dish> li = DBConnection.Entities.Dishes.ToList();
            List<DishMealTime> dm = DBConnection.Entities.DishMealTimes.ToList();

            Dish dd = (Dish)all_dish_list.SelectedItem;

            foreach (Dish d in li)
            {
                if (d.DishId == dd.DishId)
                {
                    foreach (DishMealTime dmt in dm)
                    {
                        if(dmt.DishId == d.DishId)
                        {
                            DBConnection.Entities.DishMealTimes.Remove(dmt);
                            DBConnection.Entities.Dishes.Remove(d);
                            DBConnection.Entities.SaveChanges();
                        }
                    }
                }
            }

            this.Fill();
        }

        private void add_break_dish_btn_Click(object sender, EventArgs e)
        {
            Dish obj = (Dish)all_dish_list.SelectedItem;

            break_norm += obj.Calories;

            if (Convert.ToDouble(break_day_kal_lbl.Text) < break_norm)
            {
                break_norm -= obj.Calories;

                MessageBox.Show("Вы превысили норму ккал!!!");
            }

            else
            {
                break_dish_list.Items.Add((Dish)all_dish_list.SelectedItem);

                rec_break_kal_lbl.Text = break_norm.ToString();
            }
        }

        private void del_break_dish_btn_Click(object sender, EventArgs e)
        {
            Dish obj = (Dish)break_dish_list.SelectedItem;

            break_norm -= obj.Calories;

            rec_break_kal_lbl.Text = break_norm.ToString();

            break_dish_list.Items.RemoveAt(break_dish_list.SelectedIndex);
        }

        private void add_din_dish_btn_Click(object sender, EventArgs e)
        {
            Dish obj = (Dish)all_dish_list.SelectedItem;

            din_norm += obj.Calories;

            if (Convert.ToDouble(din_day_kal_lbl.Text) < din_norm)
            {
                din_norm -= obj.Calories;

                MessageBox.Show("Вы превысили норму ккал!!!");
            }

            else
            {
                din_dish_list.Items.Add(all_dish_list.SelectedItem);

                rec_din_kal_lbl.Text = din_norm.ToString();
            }
        }

        private void del_din_dish_btn_Click(object sender, EventArgs e)
        {
            Dish obj = (Dish)din_dish_list.SelectedItem;

            din_norm -= obj.Calories;

            rec_din_kal_lbl.Text = din_norm.ToString();

            din_dish_list.Items.RemoveAt(din_dish_list.SelectedIndex);
        }

        private void add_aft_dish_btn_Click(object sender, EventArgs e)
        {
            Dish obj = (Dish)all_dish_list.SelectedItem;

            aft_norm += obj.Calories;

            if (Convert.ToDouble(aft_day_kal_lbl.Text) < aft_norm)
            {
                aft_norm -= obj.Calories;

                MessageBox.Show("Вы превысили норму ккал!!!");
            }

            else
            {
                aft_dish_list.Items.Add(all_dish_list.SelectedItem);

                rec_aft_kal_lbl.Text = aft_norm.ToString();
            }
        }

        private void del_aft_dish_btn_Click(object sender, EventArgs e)
        {
            Dish obj = (Dish)aft_dish_list.SelectedItem;

            aft_norm -= obj.Calories;

            rec_aft_kal_lbl.Text = aft_norm.ToString();

            aft_dish_list.Items.RemoveAt(aft_dish_list.SelectedIndex);
        }
    }
}