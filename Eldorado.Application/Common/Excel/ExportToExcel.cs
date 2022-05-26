using ClosedXML.Excel;
using Eldorado.Application.Orders.Queries.GetOrderDetails;
using Eldorado.Application.Orders.Queries.GetOrderList;

namespace Eldorado.Application.Common.Excel;

public class ExportToExcel
{
    public byte[] OrderExportToExcel(OrderDetailsVm order)
    {
        try
        {
            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add("Заказ");
                worksheet.Cell(1, 1).Value = "Id";
                worksheet.Cell(1, 2).Value = "Дата заказа";
                worksheet.Cell(1, 3).Value = "Сумма";
                worksheet.Cell(1, 4).Value = "Курьер Id";
                worksheet.Cell(1, 5).Value = "Имя, Фамилия";
                worksheet.Cell(1, 6).Value = "Телефон курьера";
                worksheet.Cell(1, 7).Value = "Заказчик Id";
                worksheet.Cell(1, 8).Value = "Имя, Фамилия";
                worksheet.Cell(1, 9).Value = "Телефон заказчика";
                worksheet.Cell(1, 10).Value = "Почта заказчика";
                worksheet.Cell(1, 11).Value = "Город";
                worksheet.Cell(1, 12).Value = "Улица";
                worksheet.Cell(1, 13).Value = "Дом";
                worksheet.Cell(1, 14).Value = "Квартира";
                worksheet.Cell(1, 15).Value = "Количество выбранного товара";
                worksheet.Cell(1, 16).Value = "Id Товара";
                worksheet.Cell(1, 17).Value = "Название товара";
                worksheet.Cell(1, 18).Value = "Цена товара";
                worksheet.Cell(1, 19).Value = "Производитель товара";
                
                worksheet.Outline.SummaryVLocation = XLOutlineSummaryVLocation.Top;
                
                for (int index = 1; index < 2; index++)
                {
                    for (int indexB = 0; indexB < order.SelectedProducts.Count; indexB++)
                    {
                        worksheet.Cell(indexB + index + 1, 1).Value = order.Id;
                        worksheet.Cell(indexB + index + 1, 2).Value = order.Date;
                        worksheet.Cell(indexB + index + 1, 3).Value = order.Price;
                        worksheet.Cell(indexB + index + 1, 4).Value = order.Courier?.Id;
                        worksheet.Cell(indexB + index + 1, 5).Value = $"{order.Courier?.FirstName} {order.Courier?.LastName}";
                        worksheet.Cell(indexB + index + 1, 6).Value = order.Courier?.Phone;
                        worksheet.Cell(indexB + index + 1, 7).Value = order.Customer?.Id;
                        worksheet.Cell(indexB + index + 1, 8).Value = order.Customer?.FullName;
                        worksheet.Cell(indexB + index + 1, 9).Value = order.Customer?.Phone;
                        worksheet.Cell(indexB + index + 1, 10).Value = order.Customer?.Email;
                        worksheet.Cell(indexB + index + 1, 11).Value = order.Customer?.CustomerAddress?.City;
                        worksheet.Cell(indexB + index + 1, 12).Value = order.Customer?.CustomerAddress?.Street;
                        worksheet.Cell(indexB + index + 1, 13).Value = order.Customer?.CustomerAddress?.House;
                        worksheet.Cell(indexB + index + 1, 14).Value = order.Customer?.CustomerAddress?.Apartment;
                        worksheet.Cell(indexB + index + 1, 15).Value = order.SelectedProducts[indexB].Count;
                        worksheet.Cell(indexB + index + 1, 16).Value = order.SelectedProducts[indexB].Product.Id;
                        worksheet.Cell(indexB + index + 1, 17).Value = order.SelectedProducts[indexB].Product.Name;
                        worksheet.Cell(indexB + index + 1, 18).Value = order.SelectedProducts[indexB].Product.Price;
                        worksheet.Cell(indexB + index + 1, 19).Value = order.SelectedProducts[indexB].Product.Producer;
                    }
                    if(order.SelectedProducts.Count == 1) continue;
                    
                    worksheet.Rows(index + 2, index + order.SelectedProducts.Count).Group();
                }
                
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return content;
                }
            }
        }
        catch(Exception ex)
        {
            return Array.Empty<byte>();
        }
    }
    
    public byte[] OrdersExportToExcel(IList<OrderLookupDto> orders)
    {
        try
        {
            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add("Заказ");
                worksheet.Cell(1, 1).Value = "Id";
                worksheet.Cell(1, 2).Value = "Дата заказа";
                worksheet.Cell(1, 3).Value = "Сумма";
                worksheet.Cell(1, 4).Value = "Курьер Id";
                worksheet.Cell(1, 5).Value = "Имя, Фамилия";
                worksheet.Cell(1, 6).Value = "Телефон курьера";
                worksheet.Cell(1, 7).Value = "Заказчик Id";
                worksheet.Cell(1, 8).Value = "Имя, Фамилия";
                worksheet.Cell(1, 9).Value = "Телефон заказчика";
                worksheet.Cell(1, 10).Value = "Почта заказчика";
                worksheet.Cell(1, 11).Value = "Город";
                worksheet.Cell(1, 12).Value = "Улица";
                worksheet.Cell(1, 13).Value = "Дом";
                worksheet.Cell(1, 14).Value = "Квартира";
                worksheet.Cell(1, 15).Value = "Количество выбранного товара";
                worksheet.Cell(1, 16).Value = "Id Товара";
                worksheet.Cell(1, 17).Value = "Название товара";
                worksheet.Cell(1, 18).Value = "Цена товара";
                worksheet.Cell(1, 19).Value = "Производитель товара";
                
                worksheet.Outline.SummaryVLocation = XLOutlineSummaryVLocation.Top;
                
                for (int index = 0, line = 2; index < orders.Count; index++)
                {
                    for (int indexB = 0; indexB < orders[index].SelectedProducts.Count; indexB++)
                    {
                        worksheet.Cell(indexB + line, 1).Value = orders[index].Id;
                        worksheet.Cell(indexB + line, 2).Value = orders[index].Date;
                        worksheet.Cell(indexB + line, 3).Value = orders[index].Price;
                        worksheet.Cell(indexB + line, 4).Value = orders[index].Courier?.Id;
                        worksheet.Cell(indexB + line, 5).Value = $"{orders[index].Courier?.FirstName} {orders[index].Courier?.LastName}";
                        worksheet.Cell(indexB + line, 6).Value = orders[index].Courier?.Phone;
                        worksheet.Cell(indexB + line, 7).Value = orders[index].Customer?.Id;
                        worksheet.Cell(indexB + line, 8).Value = orders[index].Customer?.FullName;
                        worksheet.Cell(indexB + line, 9).Value = orders[index].Customer?.Phone;
                        worksheet.Cell(indexB + line, 10).Value = orders[index].Customer?.Email;
                        worksheet.Cell(indexB + line, 11).Value = orders[index].Customer?.CustomerAddress?.City;
                        worksheet.Cell(indexB + line, 12).Value = orders[index].Customer?.CustomerAddress?.Street;
                        worksheet.Cell(indexB + line, 13).Value = orders[index].Customer?.CustomerAddress?.House;
                        worksheet.Cell(indexB + line, 14).Value = orders[index].Customer?.CustomerAddress?.Apartment;
                        worksheet.Cell(indexB + line, 15).Value = orders[index].SelectedProducts[indexB].Count;
                        worksheet.Cell(indexB + line, 16).Value = orders[index].SelectedProducts[indexB].Product.Id;
                        worksheet.Cell(indexB + line, 17).Value = orders[index].SelectedProducts[indexB].Product.Name;
                        worksheet.Cell(indexB + line, 18).Value = orders[index].SelectedProducts[indexB].Product.Price;
                        worksheet.Cell(indexB + line, 19).Value = orders[index].SelectedProducts[indexB].Product.Producer;
                    }

                    if (orders[index].SelectedProducts.Count == 1)
                    {
                        line = ++line;
                        continue;
                    }
                    
                    worksheet.Rows(line + 1, line - 1 + orders[index].SelectedProducts.Count).Group();
                    line = line + orders[index].SelectedProducts.Count;
                }
                
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return content;
                }
            }
        }
        catch(Exception ex)
        {
            return Array.Empty<byte>();
        }
    }
}