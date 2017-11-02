//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Alan
{
    /// <summary>
    /// Excel服务
    /// </summary>
    internal sealed class ExcelService : IExcelService
    {
        /// <summary>
        /// 数据设置实例
        /// </summary>
        private DataSet m_DataSet = null;

        /// <summary>
        /// Excel读取
        /// </summary>
        /// <param name="filePath">文件路径</param>
        public void ExcelReader(string filePath)
        {
            if (null != m_DataSet) throw new Exception("ExcelReader方法只能被调用一次!");
            m_DataSet = GetResult(filePath);          
        }

        /// <summary>
        /// 获取目标列数据
        /// </summary>
        /// <param name="sheetName">Sheet名字</param>
        /// <param name="columnName">目标列的第一个值</param>
        /// <returns>目标列的所有数据</returns>
        public string[] GetColumn(string sheetName, string columnName)
        {
            if (null == m_DataSet) throw new NullReferenceException("Excel读取有误，没有ExcelReader方法或Excel有误。");
            int ColumnCount = m_DataSet.Tables[sheetName].Columns.Count;
            int RowCount = m_DataSet.Tables[sheetName].Rows.Count;
            var rows = m_DataSet.Tables[sheetName].Rows;
            List<string> columnRecord = new List<string>();
            for (int i = 0; i < ColumnCount; i++)
            {
                if (rows[0][i].ToString()==columnName)
                {
                    for (int j = 0; j < RowCount; j++)
                    {
                        columnRecord.Add(rows[j][i].ToString());
                    }
                }
            }
            return columnRecord.ToArray();
        }

        /// <summary>
        /// 获取目标行数据
        /// </summary>
        /// <param name="sheetName">Sheet名字</param>
        /// <param name="columnName">目标行的第一个值</param>
        /// <returns>目标行的所有数据</returns>
        public string[] GetRow(string sheetName, string rowName)
        {
            if (null == m_DataSet) throw new NullReferenceException("Excel读取有误，没有ExcelReader方法或Excel有误。");
            int ColumnCount = m_DataSet.Tables[sheetName].Columns.Count;
            int RowCount = m_DataSet.Tables[sheetName].Rows.Count;
            var rows = m_DataSet.Tables[sheetName].Rows;
            List<string> rowRecord = new List<string>();
            for (int i = 0; i < RowCount; i++)
            {
                if (rows[i][0].ToString() == rowName)
                {
                    for (int j = 0; j < ColumnCount; j++)
                    {
                        rowRecord.Add(rows[i][j].ToString());
                    }
                }
            }
            return rowRecord.ToArray();
        }

        /// <summary>
        /// 获取Excel读取结果
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>DataSet实例</returns>
        private DataSet GetResult(string filePath)
        { 
            return ExcelReaderFactory.CreateBinaryReader(File.Open(filePath, FileMode.Open, FileAccess.Read)).AsDataSet();
        }

    }
}
