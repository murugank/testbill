using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Model;

namespace BillingApi.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<App> Apps { get; set; }
        public DbSet<BaseCurrency> BaseCurrencys { get; set; }
        public DbSet<CurrencyRate> CurrencyRates { get; set; }
        public DbSet<PlatformPrice> PlatformPrices { get; set; }
        public DbSet<BillingandDueDay> BillingandDueDays { get; set; }
        public DbSet<AppsRate> AppsRates { get; set; }
        public DbSet<SubscriptionHead> SubscriptionHeads { get; set; }

    }
}
