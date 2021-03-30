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
        double break_norm = 0;
        double din_norm = 0;
        double aft_norm = 0;
        double sum;

        public MainForm()
        {
            InitializeComponent();

            rec_din_kal_lbl.Text = din_norm.ToString();
            rec_break_kal_lbl.Text = break_norm.ToString();
            rec_aft_kal_lbl.Text = aft_norm.ToString();

            break_day_kal_lbl.Text = "0";
            din_day_kal_lbl.Text = "0";
            aft_day_kal_lbl.Text = "0";

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

            List<DishMealTime> li = DBConnection.Entities.DishMealTimes.ToList();

            foreach (DishMealTime d in li)
            {
                all_dish_list.Items.Add(d);
            }
        }

        public void Fill(List<DishMealTime> li)
        {
            all_dish_list.Items.Clear();

            foreach (DishMealTime d in li)
            {
                all_dish_list.Items.Add(d);
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            List<DishMealTime> li = DBConnection.Entities.DishMealTimes.ToList();
            List<DishMealTime> l2 = new List<DishMealTime>();
            List<DishMealTime> l = new List<DishMealTime>();

            if(choose_search_par_combox.Text == "Ккал")
            {
                foreach (DishMealTime d in li)
                {
                    if (d.Dish.Calories <= Convert.ToDouble(search_txt.Text))
                        l.Add(d);
                }

                this.Fill(l);
            }

            else if(choose_search_par_combox.Text == "Названию")
            {
                foreach (DishMealTime d in li)
                {
                    if (d.Dish.DishName == search_txt.Text)
                        l.Add(d);
                }

                this.Fill(l);
            }

            else if (choose_search_par_combox.Text == "Времени приема")
            {
                foreach (DishMealTime d in li)
                {
                    if (d.MealTime1.MealTimeName == search_txt.Text)
                    {
                        foreach (DishMealTime di in li)
                        {
                            if (di.Dish.DishId == d.DishId)
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
            Dish dd = (Dish)all_dish_list.SelectedItem;

            DelDish(dd);
        }

        public void DelDish(Dish di)
        {
            List<Dish> li = DBConnection.Entities.Dishes.ToList();
            List<DishMealTime> dm = DBConnection.Entities.DishMealTimes.ToList();

            if (di == null)
            {
                MessageBox.Show("Выберите блюдо для удаления");
            }
            else
            {
                foreach (Dish d in li)
                {
                    if (d.DishId == di.DishId)
                    {
                        foreach (DishMealTime dmt in dm)
                        {
                            if (dmt.DishId == d.DishId)
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
        }

        private void add_break_dish_btn_Click(object sender, EventArgs e)
        {
            DishMealTime obj = (DishMealTime)all_dish_list.SelectedItem;

            break_norm += obj.Dish.Calories;
            sum += obj.Dish.Calories;

            if (Convert.ToDouble(break_day_kal_lbl.Text) < break_norm)
            {
                break_norm -= obj.Dish.Calories;
                sum -= obj.Dish.Calories;

                MessageBox.Show("Вы превысили норму ккал!!!");
            }

            else
            {
                break_dish_list.Items.Add((DishMealTime)all_dish_list.SelectedItem);

                rec_break_kal_lbl.Text = break_norm.ToString();
            }

            earn_day_kal_lbl.Text = sum.ToString();
        }

        private void del_break_dish_btn_Click(object sender, EventArgs e)
        {
            DishMealTime obj = (DishMealTime)break_dish_list.SelectedItem;

            break_norm -= obj.Dish.Calories;
            sum -= obj.Dish.Calories;

            rec_break_kal_lbl.Text = break_norm.ToString();

            earn_day_kal_lbl.Text = sum.ToString();

            break_dish_list.Items.RemoveAt(break_dish_list.SelectedIndex);
        }

        private void add_din_dish_btn_Click(object sender, EventArgs e)
        {
            DishMealTime obj = (DishMealTime)all_dish_list.SelectedItem;

            din_norm += obj.Dish.Calories;
            sum += obj.Dish.Calories;

            if (Convert.ToDouble(din_day_kal_lbl.Text) < din_norm)
            {
                din_norm -= obj.Dish.Calories;
                sum -= obj.Dish.Calories;

                MessageBox.Show("Вы превысили норму ккал!!!");
            }

            else
            {
                din_dish_list.Items.Add(all_dish_list.SelectedItem);

                rec_din_kal_lbl.Text = din_norm.ToString();
            }

            earn_day_kal_lbl.Text = sum.ToString();
        }

        private void del_din_dish_btn_Click(object sender, EventArgs e)
        {
            try
            {
                DishMealTime obj = (DishMealTime)din_dish_list.SelectedItem;

                din_norm -= obj.Dish.Calories;
                sum -= obj.Dish.Calories;

                rec_din_kal_lbl.Text = din_norm.ToString();

                earn_day_kal_lbl.Text = sum.ToString();

                din_dish_list.Items.RemoveAt(din_dish_list.SelectedIndex);
            }

            catch
            {
                MessageBox.Show("Выберите блюдо для удаления");
            }
        }

        private void add_aft_dish_btn_Click(object sender, EventArgs e)
        {
            DishMealTime obj = (DishMealTime)all_dish_list.SelectedItem;

            aft_norm += obj.Dish.Calories;
            sum += obj.Dish.Calories;

            if (Convert.ToDouble(aft_day_kal_lbl.Text) < aft_norm)
            {
                aft_norm -= obj.Dish.Calories;
                sum -= obj.Dish.Calories;

                MessageBox.Show("Вы превысили норму ккал!!!");
            }

            else
            {
                aft_dish_list.Items.Add(all_dish_list.SelectedItem);

                rec_aft_kal_lbl.Text = aft_norm.ToString();
            }

            earn_day_kal_lbl.Text = sum.ToString();
        }

        private void del_aft_dish_btn_Click(object sender, EventArgs e)
        {
            DishMealTime obj = (DishMealTime)aft_dish_list.SelectedItem;

            aft_norm -= obj.Dish.Calories;
            sum -= obj.Dish.Calories;

            earn_day_kal_lbl.Text = sum.ToString();

            rec_aft_kal_lbl.Text = aft_norm.ToString();

            aft_dish_list.Items.RemoveAt(aft_dish_list.SelectedIndex);
        }

        private void class_toolstr_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        { 
            if (first_call_tlstr.Selected || second_call_tlstr.Selected || third_call_tlstr.Selected || four_call_tlstr.Selected)
            {
                glob_day_kal_lbl.Text = "2100";
                CheckDel();
            }

            else if (fifth_call_tlstr.Selected || six_call_tlstr.Selected || seventh_call_tlstr.Selected || eighth_call_tlstr.Selected || ninth_call_tlstr.Selected)
            {
                glob_day_kal_lbl.Text = "2500";
                CheckDel();
            }

            else if (tenth_call_tlstr.Selected || eleventh_call_tlstr.Selected)
            {
                glob_day_kal_lbl.Text = "3000";
                CheckDel();
            }

            break_day_kal_lbl.Text = CalPercent(Convert.ToDouble(glob_day_kal_lbl.Text), 25).ToString();
            din_day_kal_lbl.Text = CalPercent(Convert.ToDouble(glob_day_kal_lbl.Text), 40).ToString();
            aft_day_kal_lbl.Text = CalPercent(Convert.ToDouble(glob_day_kal_lbl.Text), 10).ToString();
        }

        public double CalPercent(double cal, double per)
        {
            double res = cal * (per/100);

            return res;
        }

        private void save_all_btn_Click(object sender, EventArgs e)
        {
            ClassMenu cm = new ClassMenu();
            List<Class> cli = DBConnection.Entities.Classes.ToList();
            List<DishMealTime> dmt = new List<DishMealTime>();

            foreach (DishMealTime d in break_dish_list.Items)
            {
                dmt.Add(d);
            }
            foreach (DishMealTime d in din_dish_list.Items)
            {
                dmt.Add(d);
            }
            foreach (DishMealTime d in aft_dish_list.Items)
            {
                dmt.Add(d);
            }

            cm.Date = menu_date.Value;

            foreach (DishMealTime d in dmt)
            {
                cm.IdDishMenu = d.Id;

                if (first_call_tlstr.Checked || second_call_tlstr.Checked || third_call_tlstr.Checked || four_call_tlstr.Checked)
                {
                    foreach (Class c in cli)
                    {
                        if (c.Num == 1 || c.Num == 2 || c.Num == 3 || c.Num == 4)
                        {
                            cm.ClassId = c.ClassId;
                            cli.Remove(c);
                            break;
                        }
                    }
                }
                else if (fifth_call_tlstr.Checked || six_call_tlstr.Checked || seventh_call_tlstr.Checked || eighth_call_tlstr.Checked || ninth_call_tlstr.Checked)
                {
                    foreach (Class c in cli)
                    {
                        if (c.Num == 5 || c.Num == 6 || c.Num == 7 || c.Num == 8 || c.Num == 9)
                        {
                            cm.ClassId = c.ClassId;
                            cli.Remove(c);
                            break;
                        }
                    }
                }
                else if (tenth_call_tlstr.Checked || eleventh_call_tlstr.Checked)
                {
                    foreach (Class c in cli)
                    {
                        if (c.Num == 10 || c.Num == 11)
                        {
                            cm.ClassId = c.ClassId;
                            cli.Remove(c);
                            break;
                        }
                    }
                }

                DBConnection.Entities.ClassMenus.Add(cm);
                DBConnection.Entities.SaveChanges();
            }

            MessageBox.Show("Меню успешно сохранено!");
        }

        public void CheckDel()
        {
            if (first_call_tlstr.Selected)
            {
                first_call_tlstr.Checked = true;
                second_call_tlstr.Checked = false;
                third_call_tlstr.Checked = false;
                four_call_tlstr.Checked = false;
                fifth_call_tlstr.Checked = false;
                six_call_tlstr.Checked = false;
                seventh_call_tlstr.Checked = false;
                eighth_call_tlstr.Checked = false;
                ninth_call_tlstr.Checked = false;
                tenth_call_tlstr.Checked = false;
                eleventh_call_tlstr.Checked = false;
            }
            else if (second_call_tlstr.Selected)
            {
                first_call_tlstr.Checked = false;
                second_call_tlstr.Checked = true;
                third_call_tlstr.Checked = false;
                four_call_tlstr.Checked = false;
                fifth_call_tlstr.Checked = false;
                six_call_tlstr.Checked = false;
                seventh_call_tlstr.Checked = false;
                eighth_call_tlstr.Checked = false;
                ninth_call_tlstr.Checked = false;
                tenth_call_tlstr.Checked = false;
                eleventh_call_tlstr.Checked = false;
            }
            else if (third_call_tlstr.Selected)
            {
                first_call_tlstr.Checked = false;
                second_call_tlstr.Checked = false;
                third_call_tlstr.Checked = true;
                four_call_tlstr.Checked = false;
                fifth_call_tlstr.Checked = false;
                six_call_tlstr.Checked = false;
                seventh_call_tlstr.Checked = false;
                eighth_call_tlstr.Checked = false;
                ninth_call_tlstr.Checked = false;
                tenth_call_tlstr.Checked = false;
                eleventh_call_tlstr.Checked = false;
            }
            else if (four_call_tlstr.Selected)
            {
                first_call_tlstr.Checked = false;
                second_call_tlstr.Checked = false;
                third_call_tlstr.Checked = false;
                four_call_tlstr.Checked = true;
                fifth_call_tlstr.Checked = false;
                six_call_tlstr.Checked = false;
                seventh_call_tlstr.Checked = false;
                eighth_call_tlstr.Checked = false;
                ninth_call_tlstr.Checked = false;
                tenth_call_tlstr.Checked = false;
                eleventh_call_tlstr.Checked = false;
            }
            else if (fifth_call_tlstr.Selected)
            {
                first_call_tlstr.Checked = false;
                second_call_tlstr.Checked = false;
                third_call_tlstr.Checked = false;
                four_call_tlstr.Checked = false;
                fifth_call_tlstr.Checked = true;
                six_call_tlstr.Checked = false;
                seventh_call_tlstr.Checked = false;
                eighth_call_tlstr.Checked = false;
                ninth_call_tlstr.Checked = false;
                tenth_call_tlstr.Checked = false;
                eleventh_call_tlstr.Checked = false;
            }
            else if (six_call_tlstr.Selected)
            {
                first_call_tlstr.Checked = false;
                second_call_tlstr.Checked = false;
                third_call_tlstr.Checked = false;
                four_call_tlstr.Checked = false;
                fifth_call_tlstr.Checked = false;
                six_call_tlstr.Checked = true;
                seventh_call_tlstr.Checked = false;
                eighth_call_tlstr.Checked = false;
                ninth_call_tlstr.Checked = false;
                tenth_call_tlstr.Checked = false;
                eleventh_call_tlstr.Checked = false;
            }
            else if (seventh_call_tlstr.Selected)
            {
                first_call_tlstr.Checked = false;
                second_call_tlstr.Checked = false;
                third_call_tlstr.Checked = false;
                four_call_tlstr.Checked = false;
                fifth_call_tlstr.Checked = false;
                six_call_tlstr.Checked = false;
                seventh_call_tlstr.Checked = true;
                eighth_call_tlstr.Checked = false;
                ninth_call_tlstr.Checked = false;
                tenth_call_tlstr.Checked = false;
                eleventh_call_tlstr.Checked = false;
            }
            else if (eighth_call_tlstr.Selected)
            {
                first_call_tlstr.Checked = false;
                second_call_tlstr.Checked = false;
                third_call_tlstr.Checked = false;
                four_call_tlstr.Checked = false;
                fifth_call_tlstr.Checked = false;
                six_call_tlstr.Checked = false;
                seventh_call_tlstr.Checked = false;
                eighth_call_tlstr.Checked = true;
                ninth_call_tlstr.Checked = false;
                tenth_call_tlstr.Checked = false;
                eleventh_call_tlstr.Checked = false;
            }
            else if (ninth_call_tlstr.Selected)
            {
                first_call_tlstr.Checked = false;
                second_call_tlstr.Checked = false;
                third_call_tlstr.Checked = false;
                four_call_tlstr.Checked = false;
                fifth_call_tlstr.Checked = false;
                six_call_tlstr.Checked = false;
                seventh_call_tlstr.Checked = false;
                eighth_call_tlstr.Checked = false;
                ninth_call_tlstr.Checked = true;
                tenth_call_tlstr.Checked = false;
                eleventh_call_tlstr.Checked = false;
            }
            else if (tenth_call_tlstr.Selected)
            {
                first_call_tlstr.Checked = false;
                second_call_tlstr.Checked = false;
                third_call_tlstr.Checked = false;
                four_call_tlstr.Checked = false;
                fifth_call_tlstr.Checked = false;
                six_call_tlstr.Checked = false;
                seventh_call_tlstr.Checked = false;
                eighth_call_tlstr.Checked = false;
                ninth_call_tlstr.Checked = false;
                tenth_call_tlstr.Checked = true;
                eleventh_call_tlstr.Checked = false;
            }
            else if (eleventh_call_tlstr.Selected)
            {
                first_call_tlstr.Checked = false;
                second_call_tlstr.Checked = false;
                third_call_tlstr.Checked = false;
                four_call_tlstr.Checked = false;
                fifth_call_tlstr.Checked = false;
                six_call_tlstr.Checked = false;
                seventh_call_tlstr.Checked = false;
                eighth_call_tlstr.Checked = false;
                ninth_call_tlstr.Checked = false;
                tenth_call_tlstr.Checked = false;
                eleventh_call_tlstr.Checked = true;
            }
        }
    }
}