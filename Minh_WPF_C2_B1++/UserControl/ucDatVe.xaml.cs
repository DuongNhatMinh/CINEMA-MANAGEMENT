using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Minh_WPF_C2_B1
{
    /// <summary>
    /// Interaction logic for ucDatVe.xaml
    /// </summary>
    public partial class ucDatVe : UserControl
    {
        const int margin = 5;
        const int padding = 5;
        const int s = 50;
        const int value = 5;
        public int nRow;
        public int nColumn;
        private int number = 0;
        private string ID;
        double price, total = 0;
        public string Name = string.Empty;
        private DateTime date;
        private CinemaStandardViewModel cinemastandardVM = new CinemaStandardViewModel();
        private CinemaVipViewModel cinemavipVM = new CinemaVipViewModel();
        private ChairViewModel chairVM = new ChairViewModel();
        private ObservableCollection<Chair> lstchair { get; set; }
        private Utilities ult = new Utilities();
        private UnitOfWork unit = new UnitOfWork();
        private Order order = null;
        private OrderViewModel OrderVM = new OrderViewModel();
        private CustomerViewModel customerVM = new CustomerViewModel();
        private BookingViewModel bookingVM = new BookingViewModel();
        private List<Order> orders = new List<Order>();
        private Customer customer = new Customer();
        private ObservableCollection<Schedule> lstSchedule { get; set; }
        private ObservableCollection<Schedule> lstSchedule2 { get; set; }
        private ObservableCollection<Showtime> lstTime { get; set; }

        public ucDatVe(string id, string name)
        {
            InitializeComponent();
            
            lstSchedule = new ObservableCollection<Schedule>(unit.schedule.Items);
            lstSchedule2 = new ObservableCollection<Schedule>();
            
            for (int i = 0; i < lstSchedule.Count; i++)
            {
                if (lstSchedule[i].Status != 1)
                {
                    lstSchedule2.Add(lstSchedule[i]);
                }
            }

            cbCinema.Items.Add(CinemaType.Standard.ToString());
            cbCinema.Items.Add(CinemaType.Vip.ToString());
            cbCinema.SelectionChanged += CbCinema_SelectionChanged;
            this.ID = id;
            this.Name = name;
            lbTrang.Content = "Order Movie: " + Name;
        }

        private void SelecTime(int index)
        {
            if(cbTime.Items.Count == 0)
            {
                if (lstSchedule2[index].Date.Day == 21)
                {
                    for (int i = 5; i < 10; i++)
                    {
                        TimeSpan time = new TimeSpan(lstSchedule2[index].lstShowtime[i].Hour, lstSchedule2[index].lstShowtime[i].Minute, 0);
                        cbTime.Items.Add(time);
                    }
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        TimeSpan time = new TimeSpan(lstSchedule2[index].lstShowtime[i].Hour, lstSchedule2[index].lstShowtime[i].Minute, 0);
                        cbTime.Items.Add(time);
                    }
                }
                cbTime.SelectionChanged += CbTime_SelectionChanged;
            }        
        }

        private void CbTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Create();   
        }

        private void Create()
        {
            lstb.Items.Clear();
            if (cbTime.SelectedIndex != -1)
            {
                chairVM.getList(ID, lstSchedule2[cbDate.SelectedIndex].Date.Day, lstSchedule2[cbDate.SelectedIndex].lstShowtime[cbTime.SelectedIndex].Hour, lstSchedule2[cbDate.SelectedIndex].lstShowtime[cbTime.SelectedIndex].Minute);
                lstchair = new ObservableCollection<Chair>(chairVM.chairRepo.Items);
   
                if (cbCinema.SelectedIndex == 0)
                {
                    CinemaStandard CinemaStandard = new CinemaStandard();
                    CinemaStandard = cinemastandardVM.getItem(0);
                    init(0);
                }
                else if (cbCinema.SelectedIndex == 1)
                {
                    CinemaVIP Cinemavip = new CinemaVIP();
                    Cinemavip = cinemavipVM.getItem(1);
                    init(25);
                }
                date = new DateTime(lstSchedule2[cbDate.SelectedIndex].Date.Year, lstSchedule2[cbDate.SelectedIndex].Date.Month, lstSchedule2[cbDate.SelectedIndex].Date.Day,
                   lstSchedule2[cbDate.SelectedIndex].lstShowtime[cbTime.SelectedIndex].Hour, lstSchedule2[cbDate.SelectedIndex].lstShowtime[cbTime.SelectedIndex].Minute, 0);
            }
        }

        private void CbDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbDate.SelectedIndex != -1)
            {
                cbTime.SelectedIndex = -1;
                SelecTime(cbDate.SelectedIndex);
            }
        }

        private void CbCinema_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbDate.Items.Count == 0)
            {
                for (int i = 0; i < lstSchedule2.Count; i++)
                {
                    DateTime date = new DateTime(lstSchedule2[i].Date.Year, lstSchedule2[i].Date.Month, lstSchedule2[i].Date.Day);
                    
                    cbDate.Items.Add(date.ToString("dd/MM/yyyy"));
                }
                cbDate.SelectionChanged += CbDate_SelectionChanged;
            }  
        }

        private void init(int idx)
        {
            int count = idx;
            nRow = value;
            nColumn = value;
            Button[][] btn = new Button[nRow][];
            for (int i = 0; i < nRow; i++)
            {
                stackpanel = new StackPanel();
                stackpanel.Children.Capacity = nColumn;
                btn[i] = new Button[nColumn];
                for (int j = 0; j < nColumn; j++)
                {
                    btn[i][j] = new Button();
                    btn[i][j].Margin = new Thickness(margin);
                    btn[i][j].Padding = new Thickness(padding);
                    btn[i][j].Height = s;
                    btn[i][j].Width = s;
                    btn[i][j].Content = lstchair[count].Name;
                    stackpanel.Orientation = Orientation.Horizontal;
                    stackpanel.Children.Add(btn[i][j]);
                    btn[i][j].Background = Brushes.Cyan;
                    btn[i][j].Click += UcBanVe_Click;
                    if(lstchair[count++].Status == 1)
                    {
                        btn[i][j].Background = Brushes.OrangeRed;
                    }

                }
                lstb.Items.Add(stackpanel);
            }
        }

        private void UcBanVe_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as Button;

            List<Order> lstorder = new List<Order>();
            //orders = new List<Order>();
            lstorder = OrderVM.getList("/Orders/Order");
            Chair chair = new Chair();
            int idx = 0, id = 0;
            for (int i = 0; i < lstorder.Count; i++)
            {
                id = lstorder[i].Id;
            }
            if (id != 1)
                id++;
            else
                id++;
            if (txtName.Text != customer.Name || txtPhone.Text != customer.Phone && cbAge.Text != string.Empty)
            {
                if (cbAge.Text != string.Empty)
                {
                    item.Background = Brushes.OrangeRed;
                    switch (cbCinema.Text)
                    {
                        case "Standard":
                            idx = ult.getIndex(unit.GetRepositoryChair.Items, item.Content.ToString(), CinemaType.Standard.ToString());
                            if (idx == -1)
                                break;
                            if (ult.check(lstchair, idx) == 1)
                            {
                                MessageBox.Show("Ghế Đã Được Đặt \n Vui Lòng Chọn Ghế Khác");
                                break;
                            }
                            chair = chairVM.SearchByName(item.Content.ToString());
                            if (cbAge.Text == "Children")
                                price = cinemastandardVM.DiscountChild(chair.Type);
                            else
                                price = cinemastandardVM.DoDiscount(chair.Type);
                            total += price;
                            customerVM.Create(txtName.Text, txtPhone.Text);
                            if (cbAge.Text == "Adult")
                                order = new Order(customerVM.customer, TicketType.Adult, CinemaType.Standard, item.Content.ToString(), price, date, id, ID, Name, total);
                            else
                                order = new Order(customerVM.customer, TicketType.Children, CinemaType.Standard, item.Content.ToString(), price, date, id, ID, Name, total);
                            orders.Add(order);
                            number++;
                            txtbNumber.Text = "Ticket Number: " + number + "\nSeat: " + item.Content.ToString();
                            lstchair[idx].Status = 1;
                            cbAge.SelectedIndex = -1;
                            break;
                        case "Vip":
                            idx = ult.getIndex(unit.GetRepositoryChair.Items, item.Content.ToString(), CinemaType.Vip.ToString());
                            if (idx == -1)
                                break;
                            if (ult.check(lstchair, idx) == 1)
                            {
                                MessageBox.Show("Ghế Đã Được Đặt \n Vui Lòng Chọn Ghế Khác");
                                break;
                            }
                            chair = chairVM.SearchByName(item.Content.ToString());
                            price = cinemavipVM.DiscountThursday(chair.Type);
                            total += price;
                            customerVM.Create(txtName.Text, txtPhone.Text);
                            order = new Order(customerVM.customer, TicketType.Adult, CinemaType.Vip, item.Content.ToString(), price, date, id, ID, Name, total);
                            orders.Add(order);
                            number++;
                            txtbNumber.Text = "Ticket Number: " + number + "/nSeat: " + item.Content.ToString();
                            lstchair[idx].Status = 1;
                            cbAge.SelectedIndex = -1;
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Ticket Type Không Được Để Trống");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Name, Phone, Ticket Type Không Được Để Trống");
                return;
            }
        }

        private void btnDat_Click(object sender, RoutedEventArgs e)
        {
            if (order != null)
            {
                bookingVM.Order(orders, order);
                txtName.Text = customer.Name;
                txtPhone.Text = customer.Phone;
                cbAge.SelectedIndex = -1;
                cbCinema.SelectedIndex = -1;
                cbDate.SelectedIndex = -1;
                cbTime.SelectedIndex = -1;
                cbDate.Items.Clear();
                cbTime.Items.Clear();
                total = 0;
                orders = new List<Order>();
            }
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            txtName.Text = customer.Name;
            txtPhone.Text = customer.Phone;
            cbAge.SelectedIndex = -1;
            cbCinema.SelectedIndex = -1;
            cbDate.SelectedIndex = -1;
            cbTime.SelectedIndex = -1;
            cbDate.Items.Clear();
            cbTime.Items.Clear();
        }
    }
}
