using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CodeFormatting_task_2
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<Report> PrepareReports()
        {
            List<Report> reports = new List<Report>();

            // Create incomes reports
            Report incomesSalesReport = this.PrepareIncomesSalesReport();
            reports.Add(incomesSalesReport);
            Report incomesSupportReport = this.PrepareIncomesSupportReport();
            reports.Add(incomesSupportReport);

            // Create expenses reports
            Report expensesPayrollReport = this.PrepareExpensesPayrollReport();
            reports.Add(expensesPayrollReport);
            Report expensesMarketingReport = this.PrepareExpensesMarketingReport();
            reports.Add(expensesMarketingReport);

            return reports;
        }

        private Report PrepareExpensesMarketingReport()
        {
            throw new NotImplementedException();
        }

        private Report PrepareExpensesPayrollReport()
        {
            throw new NotImplementedException();
        }

        private Report PrepareIncomesSupportReport()
        {
            throw new NotImplementedException();
        }

        private Report PrepareIncomesSalesReport()
        {
            throw new NotImplementedException();
        }
    }
}
