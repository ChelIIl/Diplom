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

        public MainForm()
        {
            InitializeComponent();

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
                all_dish_list.Items.Add(d.DishName + " --- " + d.Calories);
            }
        }

        public void Fill(List<Dish> li)
        {
            all_dish_list.Items.Clear();

            foreach (Dish d in li)
            {
                all_dish_list.Items.Add(d.DishName + " --- " + d.Calories);
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
    }
}
