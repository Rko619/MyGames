//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace Alan
{
    /*
        Excel读取服务发布的时候如果报错，请在Player Setting更改为 .Net 2.0
     */

    /// <summary>
    /// Excel服务接口
    /// </summary>
    public interface IExcelService
    {
        /// <summary>
        /// Excel读取
        /// </summary>
        /// <param name="filePath">文件路径</param>
        void ExcelReader(string filePath);

        /// <summary>
        /// 获取目标列数据
        /// </summary>
        /// <param name="sheetName">Sheet名字</param>
        /// <param name="columnName">目标列的第一个值</param>
        /// <returns>目标列的所有数据</returns>
        string[] GetColumn(string sheetName, string columnName);

        /// <summary>
        /// 获取目标行数据
        /// </summary>
        /// <param name="sheetName">Sheet名字</param>
        /// <param name="columnName">目标行的第一个值</param>
        /// <returns>目标行的所有数据</returns>
        string[] GetRow(string sheetName, string rowName);
    }
}