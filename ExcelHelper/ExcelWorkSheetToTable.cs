using ExcelDataReader;
using System;
using System.Data;
using System.IO;

namespace ExcelHelper
{
    public class ExcelWorkSheetToTable
    {
        private string _filepath;
        
        public DataSet Table
        {
            get
            {
                using (var stream = File.Open(_filepath, FileMode.Open, FileAccess.Read))
                {

                    // Auto-detect format, supports:
                    //  - Binary Excel files (2.0-2003 format; *.xls)
                    //  - OpenXml Excel files (2007 format; *.xlsx)
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {

 
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {

                            // Gets or sets a value indicating whether to set the DataColumn.DataType 
                            // property in a second pass.
                            UseColumnDataType = true,

                            // Gets or sets a callback to obtain configuration options for a DataTable. 
                            ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                            {

                                // Gets or sets a value indicating the prefix of generated column names.
                                EmptyColumnNamePrefix = "Column",

                                // Gets or sets a value indicating whether to use a row from the 
                                // data as column names.
                                UseHeaderRow = true,

                                // Gets or sets a callback to determine which row is the header row. 
                                // Only called when UseHeaderRow = true.
                                ReadHeaderRow = (rowReader) => {
                                    // F.ex skip the first row and use the 2nd row as column headers:
                                    //rowReader.Read();
                                },

                                // Gets or sets a callback to determine whether to include the 
                                // current row in the DataTable.
                                FilterRow = (rowReader) => {
                                    return true;
                                },
                            }
                        });

                        // The result of each spreadsheet is in result.Tables
                        return result;
                    }
                }
            }

        }

        public ExcelWorkSheetToTable(string path)
        {
            if(File.Exists(path))
            {
                _filepath = path;
            }
            
        }



    }
}
