using System.Collections.Generic;
using System.IO;
using System.Text;
using Application.Contracts.Infrastructure;
using Application.Features.Orders.Queries.GetOrdersForMonthToExcel;
using Application.Models.Export;
using ClosedXML.Excel;

namespace GlobalTicket.Infrastructure.Export.Excel
{
    public class ExportToExcelServices : IExportToExcelServices
    {
        public ExportToExcelServices()
        {
        }

        public ExcelFile GetOrderToExcel(IEnumerable<OrdersForMonthToExcelvm> orders)
        {
            ExcelFile excelFile;
            int index = 1;

            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet =
                workbook.Worksheets.Add("Orders");

                worksheet.Cell(1, 1).Value = "Id";
                worksheet.Cell(1, 2).Value = "ID USER";
                worksheet.Cell(1, 3).Value = "Order Placed".ToUpper();
                worksheet.Cell(1, 4).Value = "Order Total".ToUpper();
                worksheet.Cell(1, 5).Value = "Order Paid".ToUpper();

                foreach (var order in orders)
                {
                    worksheet.Cell(index + 1, 1).Value = order.Id;
                    worksheet.Cell(index + 1, 2).Value = order.UserId;
                    worksheet.Cell(index + 1, 3).Value = order.OrderPlaced;
                    worksheet.Cell(index + 1, 4).Value = order.OrderTotal;
                    worksheet.Cell(index + 1, 5).Value = order.OrderPaid;

                    index++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    excelFile = new ExcelFile(stream.ToArray());
                }
            }

            return excelFile;
        }

    }
}
