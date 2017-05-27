using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace AppJsonSerialiser
{
    public partial class Form1 : Form
    {
        private static readonly JavaScriptSerializer SERIALIZER = new JavaScriptSerializer() { MaxJsonLength = 50 * 1024 * 1024 };

        private class JsonClass
        {
            /// <summary>
            /// 获取调用ID
            /// </summary>
            public string requestNo { get; set; }

            /// <summary>
            /// 获取或设置服务名
            /// </summary>
            public string requestName { get; set; }

            /// <summary>
            /// 获取或设置标识ID(不同业务其含义不同)
            /// </summary>
            public string identityId { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            InitLogic();
        }

        private void InitLogic()
        {
            JsonClass jc = new JsonClass();
            jc.identityId = "ID123";
            jc.requestName = "Name测试";
            jc.requestNo = "No123";

            //json串转JsonClass
            //{AppJsonSerialiser.Form1.JsonClass}
            // identityId: "ID123"
            // requestName: "Name测试"
            // requestNo: "No123"
            this.btnSerialized.Click += delegate
            {
                JsonClass jc2 = new JsonClass();
                if (memoSerialized.EditValue == null || memoSerialized.EditValue.ToString().Length < 0)
                    MessageBox.Show("the left control is not null");
                //     将指定的 JSON 字符串转换为 T 类型的对象。
                jc2 = SERIALIZER.Deserialize<JsonClass>(memoSerialized.EditValue.ToString());

                memoToSerialize.EditValue = jc2;
            };

            //JsonClass转json串
            //{"requestNo":"No123","requestName":"Name测试","identityId":"ID123"}
            this.btnToSerialize.Click += delegate
            {
                //     将对象转换为 JSON 字符串。
                string str = SERIALIZER.Serialize(jc);
                this.memoSerialized.EditValue = str;
            };
        }
    }
}
