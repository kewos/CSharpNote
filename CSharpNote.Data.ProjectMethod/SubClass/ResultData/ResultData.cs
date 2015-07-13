using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.ProjectMethod.SubClass.ResultData
{
    public class ResultData
    {
        #region Field
        private Boolean success;
        private String message;
        private Object data;
        #endregion

        #region Constructor
        public ResultData()
        { 
        }
        public ResultData(Exception exception, String extraInfo = "")
        {
            success = false;

            var sb = new StringBuilder();
            sb.Append(string.Format("Exception:{0}", exception.Message));
            if (extraInfo != string.Empty)
            {
                sb.Append(string.Format("ExtraInfo:{0}", extraInfo));
            }

            message = sb.ToString();
        }

        public ResultData(Boolean success, String message = "", Object data = null)
        {
            this.success = success;
            this.message = message;
            this.data = data;
        }
        #endregion

        #region Property
        public Boolean Success 
        { 
            get 
            { 
                return success; 
            } 
        }
        public String Message 
        { 
            get 
            { 
                return message; 
            } 
        }
        public Object Data 
        { 
            get 
            { 
                return data; 
            } 
        } 
        #endregion

        #region MyRegion
        public override String ToString()
        {
            return message;
        }

        public T GetData<T>()
        {
            return (T)data;
        } 
        #endregion

        #region Type Conversion
        public static implicit operator Boolean(ResultData result)
        {
            return result.success;
        }

        public static implicit operator String(ResultData result)
        {
            return result.message;
        }

        public static implicit operator ResultData(String result)
        {
            return new ResultData(result == String.Empty, result);
        }

        public static implicit operator ResultData(Boolean result)
        {
            return new ResultData(result);
        }
        #endregion
    }
}
