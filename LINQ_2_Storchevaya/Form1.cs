using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQ_2_Storchevaya
{
    public partial class Form1 : Form
    {
        private List<Department> departments;
        private List<Employ> employees;
        public Form1()
        {
            InitializeComponent();
            InitializeData();
        }
        private void InitializeData()
        {
            departments = new List<Department>
            {
                new Department {Name = "Отдел закупок", Reg = "Германия"},
                new Department {Name = "Отдел продаж", Reg = "Испания"},
                new Department {Name = "Отдел маркетинга", Reg = "Испания"}
            };

            employees = new List<Employ>
            {
                new Employ {Name = "Иванов", Department = "Отдел закупок"},
                new Employ {Name = "Петров", Department = "Отдел закупок"},
                new Employ {Name = "Сидоров", Department = "Отдел продаж"},
                new Employ {Name = "Лямин", Department = "Отдел продаж"},
                new Employ {Name = "Сидоренко", Department = "Отдел маркетинга"},
                new Employ {Name = "Кривоносов", Department = "Отдел продаж"}
            };
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            label1.Text = "А: Группировка по отделам";
            var query = from emp in employees
                        join dept in departments on emp.Department.Trim() equals dept.Name
                        group emp by dept into g
                        orderby g.Key.Name
                        select new
                        {
                            Department = g.Key,
                            Employees = g.ToList()
                        };
            foreach (var group in query)
            {
                listBox1.Items.Add($"{group.Department.Name} (Регион: {group.Department.Reg})");

                foreach (var emp in group.Employees)
                {
                    listBox1.Items.Add($"   • {emp.Name}");
                }
                listBox1.Items.Add(""); //Пустая строка
            }
            listBox1.Items.Add($"Всего отделов: {query.Count()}");
            listBox1.Items.Add($"Всего сотрудников: {employees.Count}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            label1.Text = "Б: Сотрудники из регионов на 'И'";
            var query = from emp in employees
                        join dept in departments on emp.Department.Trim() equals dept.Name
                        where dept.Reg.StartsWith("И")
                        select new
                        {
                            Сотрудник = emp.Name,
                            Отдел = dept.Name,
                            Регион = dept.Reg
                        };
            foreach (var item in query.OrderBy(x => x.Сотрудник))
            {
                listBox1.Items.Add($"• {item.Сотрудник} - {item.Отдел} ({item.Регион})");
            }
            if (!query.Any())
            {
                listBox1.Items.Add("Сотрудники не найдены");
            }
            else
            {
                listBox1.Items.Add($"Найдено: {query.Count()} сотрудников");
            }
        }
    }
}
