using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minh_WPF_C2_B1
{
    class UnitOfWork
    {
        public RepositoryBase<Chair> chairs;
        private ChairViewModel chairVM = new ChairViewModel();
        public RepositoryBase<Movie> movies;
        private MovieViewModel movieVM = new MovieViewModel();
        public RepositoryBase<Account> acc = new RepositoryBase<Account>();
        private AccountViewModel accVM = new AccountViewModel();
        public RepositoryBase<Schedule> schedule = new RepositoryBase<Schedule>();
        private ScheduleViewModel scheduleVM = new ScheduleViewModel();
        public RepositoryBase<Order> order = new RepositoryBase<Order>();
        private OrderViewModel orderVM = new OrderViewModel();

        public RepositoryBase<Chair> GetRepositoryChair
        {
            get
            {
                if (this.chairs == null)
                    this.chairs = new RepositoryBase<Chair>();
                return chairs;
            }
        }

        public RepositoryBase<Movie> GetRepositoryMovie
        {
            get
            {
                if (this.movies == null)
                    this.movies = new RepositoryBase<Movie>();
                return movies;
            }
        }

        public RepositoryBase<Account> GetRepositoryAccount
        {
            get
            {
                if (this.acc == null)
                    this.acc = new RepositoryBase<Account>();
                return acc;
            }
        }

        public RepositoryBase<Schedule> GetRepositorySchedule
        {
            get
            {
                if (this.schedule == null)
                    this.schedule = new RepositoryBase<Schedule>();
                return schedule;
            }
        }

        public RepositoryBase<Order> GetRepositoryOrder
        {
            get
            {
                if (this.order == null)
                    this.order = new RepositoryBase<Order>();
                return order;
            }
        }

        public UnitOfWork()
        {
            chairs = new RepositoryBase<Chair>();
            movies = new RepositoryBase<Movie>();
            acc = new RepositoryBase<Account>();
            schedule = new RepositoryBase<Schedule>();
            order = new RepositoryBase<Order>();

            // Get data;
            chairs.BulkInsert(chairVM.getList("//Chair"));
            movies.BulkInsert(movieVM.getList("Movie"));
            acc.BulkInsert(accVM.getList("/Accounts/Account"));
            schedule.BulkInsert(scheduleVM.getList("Schedule"));
            order.BulkInsert(orderVM.getList("/Orders/Order"));
        }

        public UnitOfWork(string pathData)
        {
            chairs = new RepositoryBase<Chair>();

            // Get data;
            chairs.BulkInsert(chairVM.getList("//Chair", pathData));
        }
    }
}
