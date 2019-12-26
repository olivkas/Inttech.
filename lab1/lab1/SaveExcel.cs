using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace lab1
{
    class SaveExcel
    {
        public static void SaveGroupList(Group group, string file)
        {
            var newFile = new FileInfo(file + ".xlsx");
            using (ExcelPackage xlPackage = new ExcelPackage(newFile))
            {

                ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets.Add("Group");

                for (int i = 0; i < group.header.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = group.header[i];
                    worksheet.Column(i + 1).Width = 20;
                }
                worksheet.Cells[1, group.header.Length + 1].Value = "Average mark";
                worksheet.Column(group.header.Length + 1).Width = 20;

                for (int i = 0, row = 2; i < group.students.Count; i++, row++)
                {
                    worksheet.Cells[row, 1].Value = group.students[i].surname;
                    worksheet.Cells[row, 2].Value = group.students[i].name;
                    worksheet.Cells[row, 3].Value = group.students[i].patronymic;
                    int col = 4;
                    for (int j = 0; j < group.students[i].subjects.Count; j++, col++)
                    {
                        worksheet.Cells[row, col].Value = group.students[i].subjects[j].mark;
                    }
                    worksheet.Cells[row, col].Value = group.students[i].totalScore;
                }

                int lastRow = group.students.Count + 2;


                worksheet.Cells[lastRow, 3].Value = "Average by group:";

                for (int i = 0; i < group.averageMarks.Count - 1; i++)
                {
                    worksheet.Cells[lastRow, i + 4].Value = group.averageMarks[group.header[i + 3]];
                }

                try
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                    }
                    xlPackage.Save();
                }
                catch
                {
                    Console.WriteLine("Invalid file name or file type.");
                }
            }
        }
    }
}
