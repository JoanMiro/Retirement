namespace Retirement.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Timers;

    public class CountdownViewModel : BaseViewModel
    {
        private readonly DateTime retirementDateTime = new(2022, 7, 8, 17, 0, 0);
        private DateTime nextHolidayDateTime;
        private readonly DateTime nextMarathonDateTime = new(2022, 5, 2, 10, 0, 0);

        public CountdownViewModel()
        {
            Title = "Countdown";
            ConfigureHolidays();
            var timeToGoTimer = new Timer(1000);
            timeToGoTimer.Elapsed += this.TimeToGoTimer_Elapsed;
            timeToGoTimer.Start();
        }

        private void ConfigureHolidays()
        {
            var skiing1 = new DateTime(2022, 3, 4);
            var skiing2 = new DateTime(2022, 3, 26);
            var skiathos = new DateTime(2022, 5, 27);
            var now = DateTime.Today;

            if (skiing1 > now)
            {
                this.nextHolidayDateTime = skiing1;
            }
            else if (skiing2 > now)
            {
                this.nextHolidayDateTime = skiing2;
            }
            else if (skiathos > now)
            {
                this.nextHolidayDateTime = skiathos;
            }
            else
            {
                this.nextHolidayDateTime = this.retirementDateTime;
            }
        }

        private void TimeToGoTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var retirementRemaining = this.retirementDateTime - DateTime.Now;

            this.RetirementTimeToGo = new CountdownInfo
            {
                Title = "Retirement",
                Days = $"Days: {retirementRemaining.Days}",
                Hours = $"Hours: {retirementRemaining.Hours}",
                Minutes = $"Minutes: {retirementRemaining.Minutes}",
                Seconds = $"Seconds: {retirementRemaining.Seconds}"
            };

            var holidayRemaining = this.nextHolidayDateTime - DateTime.Now;

            this.NextHolidayTimeToGo = new CountdownInfo
            {
                Title = "Holiday",
                Days = $"Days: {holidayRemaining.Days}",
                Hours = $"Hours: {holidayRemaining.Hours}",
                Minutes = $"Minutes: {holidayRemaining.Minutes}",
                Seconds = $"Seconds: {holidayRemaining.Seconds}"
            };

            var marathonRemaining = this.nextMarathonDateTime - DateTime.Now;

            this.NextMarathonTimeToGo = new CountdownInfo
            {
                Title = "Marathon",
                Days = $"Days: {marathonRemaining.Days}",
                Hours = $"Hours: {marathonRemaining.Hours}",
                Minutes = $"Minutes: {marathonRemaining.Minutes}",
                Seconds = $"Seconds: {marathonRemaining.Seconds}"
            };

            this.Countdowns ??= new ObservableCollection<CountdownInfo>
            {
                this.RetirementTimeToGo,
                this.NextHolidayTimeToGo
            };
        }

        private CountdownInfo retirementRetirementTimeToGo;

        private CountdownInfo nextHolidayTimeToGo;
        private CountdownInfo nextMarathonTimeToGo;

        public ObservableCollection<CountdownInfo> Countdowns { get; set; }

        public CountdownInfo RetirementTimeToGo
        {
            get => this.retirementRetirementTimeToGo;
            set => SetProperty(ref this.retirementRetirementTimeToGo, value);
        }

        public CountdownInfo NextHolidayTimeToGo
        {
            get => this.nextHolidayTimeToGo;
            set => SetProperty(ref this.nextHolidayTimeToGo, value);
        }
        public CountdownInfo NextMarathonTimeToGo
        {
            get => this.nextMarathonTimeToGo;
            set => SetProperty(ref this.nextMarathonTimeToGo, value);
        }
    }
}
