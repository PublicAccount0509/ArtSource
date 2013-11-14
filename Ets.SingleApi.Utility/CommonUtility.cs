namespace Ets.SingleApi.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Runtime.Serialization.Json;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web.Script.Serialization;
    using System.Xml.Linq;

    /// <summary>
    /// 类名称：CommonUtility
    /// 命名空间：Ets.SingleApi.Utility
    /// 类功能：定义一些公用的方法
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/10 9:34
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public static class CommonUtility
    {
        #region Write log

        /// <summary>
        /// Writes the log.
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="name">The name</param>
        /// <param name="logType">Type of the log.</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:34
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static void WriteLog(this string message, string name, Log4NetType logType)
        {
            var log = Log4NetUtility.GetInstance().GetLog(name);
            if (log == null)
            {
                return;
            }

            if (logType == Log4NetType.Debug)
            {
                log.Debug(message);
                return;
            }

            if (logType == Log4NetType.Error)
            {
                log.Error(message);
                return;
            }

            if (logType == Log4NetType.Fatal)
            {
                log.Debug(message);
                return;
            }

            if (logType == Log4NetType.Info)
            {
                log.Info(message);
                return;
            }

            log.Warn(message);
        }

        /// <summary>
        /// Writes the log.
        /// </summary>
        /// <param name="exception">The exception</param>
        /// <param name="name">The name</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:34
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static void WriteLog(this Exception exception, string name)
        {
            var log = Log4NetUtility.GetInstance().GetLog(name);
            if (log == null)
            {
                return;
            }

            log.Error(exception);
        }

        #endregion

        #region Json Serialize and Deserialize

        /// <summary>
        /// The method indicates the object serialized using json.
        /// </summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        /// <param name="obj">The TType of obj</param>
        /// <returns>
        /// The json string
        /// </returns>
        /// Creator:zhouchao
        /// Creation Date:11/15/2011 2:50 PM
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public static string Serialize<TType>(this TType obj)
        {
            try
            {
                if (obj.GetType().Name.Contains("<>f__AnonymousType"))
                {
                    var serializer = new JavaScriptSerializer();
                    return serializer.Serialize(obj);
                }

                using (var ms = new MemoryStream())
                {
                    var serializer = new DataContractJsonSerializer(obj.GetType(), new List<Type>(), int.MaxValue, true, null, false);
                    serializer.WriteObject(ms, obj);
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            catch (InvalidDataException exception)
            {
                exception.WriteLog(string.Empty);
                return null;
            }
            catch (ArgumentNullException exception)
            {
                exception.WriteLog(string.Empty);
                return null;
            }
            catch (Exception exception)
            {
                exception.WriteLog(string.Empty);
                return null;
            }
        }

        /// <summary>
        /// The method indicates the json deserialized.
        /// </summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        /// <param name="json">The value of json.</param>
        /// <returns>
        /// The TType
        /// </returns>
        /// Creator:zhouchao
        /// Creation Date:11/15/2011 2:57 PM
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public static TType Deserialize<TType>(this string json)
        {
            var model = Activator.CreateInstance<TType>();
            if (string.IsNullOrEmpty(json) || string.IsNullOrWhiteSpace(json))
            {
                return model;
            }

            try
            {
                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                {
                    var serializer = new DataContractJsonSerializer(model.GetType(), new List<Type>(), int.MaxValue, true, null, false);
                    return (TType)serializer.ReadObject(ms);
                }
            }
            catch (InvalidCastException exception)
            {
                exception.WriteLog(string.Empty);
                return model;
            }
            catch (ArgumentNullException exception)
            {
                exception.WriteLog(string.Empty);
                return model;
            }
        }

        /// <summary>
        /// The method indicates the json deserialized.
        /// </summary>
        /// <param name="json">The value of json.</param>
        /// <returns>
        /// The string
        /// </returns>
        /// Creator:zhouchao
        /// Creation Date:11/15/2011 2:57 PM
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public static string Deserialize(this string json)
        {
            if (string.IsNullOrEmpty(json) || string.IsNullOrWhiteSpace(json))
            {
                return string.Empty;
            }

            try
            {
                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                {
                    var serializer = new DataContractJsonSerializer(typeof(string));
                    return (string)serializer.ReadObject(ms);
                }
            }
            catch (InvalidCastException exception)
            {
                exception.WriteLog(string.Empty);
                return string.Empty;
            }
            catch (ArgumentNullException exception)
            {
                exception.WriteLog(string.Empty);
                return string.Empty;
            }
        }

        #endregion

        #region 字符串转化为拼音

        /// <summary>
        /// 字段PyValue
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/7/2013 2:18 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private static readonly int[] PyValue = new []{-20319,-20317,-20304,-20295,-20292,-20283,-20265,-20257,-20242,-20230,-20051,-20036,-20032,-20026,  
          -20002,-19990,-19986,-19982,-19976,-19805,-19784,-19775,-19774,-19763,-19756,-19751,-19746,-19741,-19739,-19728,  
          -19725,-19715,-19540,-19531,-19525,-19515,-19500,-19484,-19479,-19467,-19289,-19288,-19281,-19275,-19270,-19263,  
          -19261,-19249,-19243,-19242,-19238,-19235,-19227,-19224,-19218,-19212,-19038,-19023,-19018,-19006,-19003,-18996,  
          -18977,-18961,-18952,-18783,-18774,-18773,-18763,-18756,-18741,-18735,-18731,-18722,-18710,-18697,-18696,-18526,  
          -18518,-18501,-18490,-18478,-18463,-18448,-18447,-18446,-18239,-18237,-18231,-18220,-18211,-18201,-18184,-18183,  
          -18181,-18012,-17997,-17988,-17970,-17964,-17961,-17950,-17947,-17931,-17928,-17922,-17759,-17752,-17733,-17730,  
          -17721,-17703,-17701,-17697,-17692,-17683,-17676,-17496,-17487,-17482,-17468,-17454,-17433,-17427,-17417,-17202,  
          -17185,-16983,-16970,-16942,-16915,-16733,-16708,-16706,-16689,-16664,-16657,-16647,-16474,-16470,-16465,-16459,  
          -16452,-16448,-16433,-16429,-16427,-16423,-16419,-16412,-16407,-16403,-16401,-16393,-16220,-16216,-16212,-16205,  
          -16202,-16187,-16180,-16171,-16169,-16158,-16155,-15959,-15958,-15944,-15933,-15920,-15915,-15903,-15889,-15878,  
          -15707,-15701,-15681,-15667,-15661,-15659,-15652,-15640,-15631,-15625,-15454,-15448,-15436,-15435,-15419,-15416,  
          -15408,-15394,-15385,-15377,-15375,-15369,-15363,-15362,-15183,-15180,-15165,-15158,-15153,-15150,-15149,-15144,  
          -15143,-15141,-15140,-15139,-15128,-15121,-15119,-15117,-15110,-15109,-14941,-14937,-14933,-14930,-14929,-14928,  
          -14926,-14922,-14921,-14914,-14908,-14902,-14894,-14889,-14882,-14873,-14871,-14857,-14678,-14674,-14670,-14668,  
          -14663,-14654,-14645,-14630,-14594,-14429,-14407,-14399,-14384,-14379,-14368,-14355,-14353,-14345,-14170,-14159,  
          -14151,-14149,-14145,-14140,-14137,-14135,-14125,-14123,-14122,-14112,-14109,-14099,-14097,-14094,-14092,-14090,  
          -14087,-14083,-13917,-13914,-13910,-13907,-13906,-13905,-13896,-13894,-13878,-13870,-13859,-13847,-13831,-13658,  
          -13611,-13601,-13406,-13404,-13400,-13398,-13395,-13391,-13387,-13383,-13367,-13359,-13356,-13343,-13340,-13329,  
          -13326,-13318,-13147,-13138,-13120,-13107,-13096,-13095,-13091,-13076,-13068,-13063,-13060,-12888,-12875,-12871,  
          -12860,-12858,-12852,-12849,-12838,-12831,-12829,-12812,-12802,-12607,-12597,-12594,-12585,-12556,-12359,-12346,  
          -12320,-12300,-12120,-12099,-12089,-12074,-12067,-12058,-12039,-11867,-11861,-11847,-11831,-11798,-11781,-11604,  
          -11589,-11536,-11358,-11340,-11339,-11324,-11303,-11097,-11077,-11067,-11055,-11052,-11045,-11041,-11038,-11024,  
          -11020,-11019,-11018,-11014,-10838,-10832,-10815,-10800,-10790,-10780,-10764,-10587,-10544,-10533,-10519,-10331,  
          -10329,-10328,-10322,-10315,-10309,-10307,-10296,-10281,-10274,-10270,-10262,-10260,-10256,-10254};

        /// <summary>
        /// 字段PyName
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/7/2013 2:18 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private static readonly string[] PyName = new []{"a","ai","an","ang","ao","ba","bai","ban","bang","bao","bei","ben","beng","bi","bian","biao",  
        "bie","bin","bing","bo","bu","ca","cai","can","cang","cao","ce","ceng","cha","chai","chan","chang","chao","che","chen",  
        "cheng","chi","chong","chou","chu","chuai","chuan","chuang","chui","chun","chuo","ci","cong","cou","cu","cuan","cui",  
        "cun","cuo","da","dai","dan","dang","dao","de","deng","di","dian","diao","die","ding","diu","dong","dou","du","duan",  
        "dui","dun","duo","e","en","er","fa","fan","fang","fei","fen","feng","fo","fou","fu","ga","gai","gan","gang","gao",  
        "ge","gei","gen","geng","gong","gou","gu","gua","guai","guan","guang","gui","gun","guo","ha","hai","han","hang",  
        "hao","he","hei","hen","heng","hong","hou","hu","hua","huai","huan","huang","hui","hun","huo","ji","jia","jian",  
        "jiang","jiao","jie","jin","jing","jiong","jiu","ju","juan","jue","jun","ka","kai","kan","kang","kao","ke","ken",  
        "keng","kong","kou","ku","kua","kuai","kuan","kuang","kui","kun","kuo","la","lai","lan","lang","lao","le","lei",  
        "leng","li","lia","lian","liang","liao","lie","lin","ling","liu","long","lou","lu","lv","luan","lue","lun","luo",  
        "ma","mai","man","mang","mao","me","mei","men","meng","mi","mian","miao","mie","min","ming","miu","mo","mou","mu",  
        "na","nai","nan","nang","nao","ne","nei","nen","neng","ni","nian","niang","niao","nie","nin","ning","niu","nong",  
        "nu","nv","nuan","nue","nuo","o","ou","pa","pai","pan","pang","pao","pei","pen","peng","pi","pian","piao","pie",  
        "pin","ping","po","pu","qi","qia","qian","qiang","qiao","qie","qin","qing","qiong","qiu","qu","quan","que","qun",  
        "ran","rang","rao","re","ren","reng","ri","rong","rou","ru","ruan","rui","run","ruo","sa","sai","san","sang",  
        "sao","se","sen","seng","sha","shai","shan","shang","shao","she","shen","sheng","shi","shou","shu","shua",  
        "shuai","shuan","shuang","shui","shun","shuo","si","song","sou","su","suan","sui","sun","suo","ta","tai",  
        "tan","tang","tao","te","teng","ti","tian","tiao","tie","ting","tong","tou","tu","tuan","tui","tun","tuo",  
        "wa","wai","wan","wang","wei","wen","weng","wo","wu","xi","xia","xian","xiang","xiao","xie","xin","xing",  
        "xiong","xiu","xu","xuan","xue","xun","ya","yan","yang","yao","ye","yi","yin","ying","yo","yong","you",  
        "yu","yuan","yue","yun","za","zai","zan","zang","zao","ze","zei","zen","zeng","zha","zhai","zhan","zhang",  
        "zhao","zhe","zhen","zheng","zhi","zhong","zhou","zhu","zhua","zhuai","zhuan","zhuang","zhui","zhun","zhuo",  
        "zi","zong","zou","zu","zuan","zui","zun","zuo"};

        /// <summary>
        /// 把汉字转换成拼音(全拼)
        /// </summary>
        /// <param name="source">汉字字符串</param>
        /// <returns>转换后的拼音(全拼)字符串</returns>
        /// 创建者：周超
        /// 创建日期：11/7/2013 2:17 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string ToFullSpell(this string source)
        {
            if (source.IsEmptyOrNull()) //输入为空 
            {
                return string.Empty;
            }

            var maxLength = source.Trim().Length;

            //字符处理 
            source = source.Trim().Replace(" ", "").Replace("?", "_").Replace("\\", "_").Replace("/", "_").Replace(":", "").Replace("*", "").Replace(">", "").Replace("<", "").Replace("?", "").Replace("|", "").Replace("\"", "'").Replace("(", "_").Replace(")", "_").Replace(";", "_");
            source = source.Replace("，", ",").Replace("\"", "").Replace("\"", "").Replace("；", "_").Replace("。", "_").Replace("[", "").Replace("]", "").Replace("【", "").Replace("】", "");
            source = source.Replace("{", "").Replace("}", "").Replace("^", "").Replace("&", "_").Replace("=", "").Replace("~", "_").Replace("@", "_").Replace("￥", "");
            if (source.Length > maxLength)
            {
                source = source.Substring(0, maxLength);
            }

            var regex = new Regex(@"([a-zA-Z0-9\._]+)", RegexOptions.IgnoreCase);
            if (regex.IsMatch(source) && source.Equals(regex.Match(source).Groups[1].Value, StringComparison.OrdinalIgnoreCase))
            {
                return source;
            }

            // 匹配中文字符           
            regex = new Regex("^[\u4e00-\u9fa5]$");
            var list = new List<string>();
            foreach (var item in source.ToCharArray())
            {
                if (!regex.IsMatch(item.ToString()))
                {
                    list.Add(item.ToString());
                    continue;
                }

                var array = Encoding.Default.GetBytes(item.ToString());
                var i1 = (short)(array[0]);
                var i2 = (short)(array[1]);
                var chrAsc = i1 * 256 + i2 - 65536;
                if (chrAsc > 0 && chrAsc < 160)
                {
                    list.Add(item.ToString());
                    continue;
                }

                // 修正部分文字           
                if (chrAsc == -9254) // 修正"圳"字 
                {
                    list.Add("Zhen");
                    continue;
                }

                // 修正部分文字           
                if (chrAsc == -6987) // 修正"涞"字 
                {
                    list.Add("Lai");
                    continue;
                }

                for (var i = (PyValue.Length - 1); i >= 0; i--)
                {
                    if (PyValue[i] > chrAsc)
                    {
                        continue;
                    }

                    list.Add(PyName[i]);
                }
            }

            return string.Join(string.Empty, list);
        }

        /// <summary>
        /// 把汉字转换成拼音(简拼)
        /// </summary>
        /// <param name="source">汉字字符串</param>
        /// <returns>转换后的拼音(简拼)字符串</returns>
        /// 创建者：周超
        /// 创建日期：11/7/2013 2:17 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string ToSimpleSpell(this string source)
        {
            // 匹配中文字符
            var regex = new Regex("^[\u4e00-\u9fa5]$");
            var list = new List<string>();
            foreach (var item in source.ToCharArray())
            {
                if (!regex.IsMatch(item.ToString()))
                {
                    continue;
                }

                var array = Encoding.Default.GetBytes(item.ToString());
                var i1 = (short)(array[0]);
                var i2 = (short)(array[1]);
                var chrAsc = i1 * 256 + i2 - 65536;
                if (chrAsc > 0 && chrAsc < 160)
                {
                    list.Add(item.ToString());
                    continue;
                }

                // 修正部分文字           
                if (chrAsc == -9254) // 修正"圳"字 
                {
                    list.Add("Z");
                    continue;
                }

                // 修正部分文字           
                if (chrAsc == -6987) // 修正"涞"字 
                {
                    list.Add("L");
                    continue;
                }

                for (var i = (PyValue.Length - 1); i >= 0; i--)
                {
                    if (PyValue[i] > chrAsc)
                    {
                        continue;
                    }

                    list.Add(PyName[i][0].ToString());
                }
            }

            return string.Join(string.Empty, list).ToLower();
        }

        #endregion

        /// <summary>
        /// 读取header标头，如果不存在，返回空字符串
        /// </summary>
        /// <param name="headers">The headers</param>
        /// <param name="key">The key</param>
        /// <returns>
        /// The String
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/29/2013 5:17 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string Read(this HttpRequestHeaders headers, string key)
        {
            IEnumerable<string> values;
            headers.TryGetValues(key, out values);
            return values == null ? string.Empty : values.FirstOrDefault() ?? string.Empty;
        }

        /// <summary>
        /// 获取当前节点值
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="name">The name</param>
        /// <returns>
        /// 返回当前节点值
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 20:12
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string GetAttribute(this XElement element, string name)
        {
            if (element == null)
            {
                return string.Empty;
            }

            var attribute = element.Attribute(name);
            return attribute == null ? string.Empty : attribute.Value;
        }

        /// <summary>
        /// 判定字符串是否为空或null
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 10:47
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static bool IsEmptyOrNull(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            return value.Trim().Length == 0;
        }

        /// <summary>
        /// The method will 
        /// </summary>
        /// <param name="d">The d</param>
        /// <returns>
        /// The Double
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private static double Rad(double d)
        {
            return d * Math.PI / 180.0;
        }

        /// <summary>
        /// Gets the distance.
        /// </summary>
        /// <param name="lat1">The lat1</param>
        /// <param name="lng1">The lng1</param>
        /// <param name="lat2">The lat2</param>
        /// <param name="lng2">The lng2</param>
        /// <returns>
        /// Double
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            var radLat1 = Rad(lat1);
            var radLat2 = Rad(lat2);
            var lat = radLat1 - radLat2;
            var lng = Rad(lng1) - Rad(lng2);
            var distance = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(lat / 2), 2) +
             Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(lng / 2), 2)));
            distance = distance * 6376.5;
            return distance;
        }

        /// <summary>
        /// Md5加密
        /// </summary>
        /// <param name="str">待加密的字串</param>
        /// <returns>
        /// 返回加密字串
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 9:48
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string Md5(this string str)
        {
            var b = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(str));
            var ret = string.Empty;
            for (var i = 0; i < b.Length; i++)
            {
                ret += b[i].ToString("X").PadLeft(2, '0');
            }

            return ret;
        }

        /// <summary>
        /// 获取Token过期时间
        /// </summary>
        /// <returns>
        /// 返回Token过期时间
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 11:18
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int GetTokenExpiresIn()
        {
            const int TokenExpiresIn = 60 * 60 * 24 * 30; //30天
            int tempTokenExpiresIn;
            if (int.TryParse(ConfigurationManager.AppSettings["TokenExpiresIn"], out tempTokenExpiresIn))
            {
                return tempTokenExpiresIn;
            }

            return TokenExpiresIn;
        }

        /// <summary>
        /// 获取Token类型
        /// </summary>
        /// <returns>
        /// 返回Token类型
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 11:36
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string GetTokenType()
        {
            return "Bearer";
        }

        /// <summary>
        /// 生成随机指定长度的数字
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns>
        /// 返回随机码
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 21:43
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string RandNum(int length)
        {
            var list = new List<int>();
            for (var i = 0; i < length; i++)
            {
                list.Add(new Random(i * ((int)DateTime.Now.Ticks)).Next(0, 10));
            }

            return string.Concat(list);
        }

        /// <summary>
        /// 将Object类型转换为string
        /// </summary>
        /// <param name="obj">待转换的值</param>
        /// <returns>
        /// 返回转换后的值
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/18 21:39
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string ObjectToString(this object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            return obj.ToString();
        }

        /// <summary>
        /// 将Object类型转换为Int32
        /// </summary>
        /// <param name="obj">待转换的值</param>
        /// <returns>
        /// 返回转换后的值
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/18 21:39
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int? ObjectToInt32(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            int result;
            if (int.TryParse(obj.ToString(), out result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// 将Object类型转换为Int32
        /// </summary>
        /// <param name="obj">待转换的值</param>
        /// <returns>
        /// 返回转换后的值
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/18 21:39
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int ObjectToInt(this object obj)
        {
            if (obj == null)
            {
                return 0;
            }

            int result;
            if (int.TryParse(obj.ToString(), out result))
            {
                return result;
            }

            return 0;
        }

        /// <summary>
        /// 将Object类型转换为Int32
        /// </summary>
        /// <param name="obj">待转换的值</param>
        /// <returns>
        /// 返回转换后的值
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/18 21:39
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int? ObjectToIntObject(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            int result;
            if (int.TryParse(obj.ToString(), out result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// 将Object类型转换为Double
        /// </summary>
        /// <param name="obj">待转换的值</param>
        /// <returns>
        /// 返回转换后的值
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/18 21:39
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static double? ObjectToDouble(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            double result;
            if (double.TryParse(obj.ToString(), out result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// 将Object类型转换为Decimal
        /// </summary>
        /// <param name="obj">待转换的值</param>
        /// <returns>
        /// 返回转换后的值
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/18 21:39
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static decimal? ObjectToDecimal(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            decimal result;
            if (decimal.TryParse(obj.ToString(), out result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// 将Object类型转换为Boolean
        /// </summary>
        /// <param name="obj">待转换的值</param>
        /// <returns>
        /// 返回转换后的值
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/18 21:39
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static bool? ObjectToBoolean(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            bool result;
            if (bool.TryParse(obj.ToString(), out result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// 将Object类型转换为DateTime
        /// </summary>
        /// <param name="obj">待转换的值</param>
        /// <returns>
        /// 返回转换后的值
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/18 21:39
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static DateTime? ObjectToDateTime(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            DateTime result;
            if (DateTime.TryParse(obj.ToString(), out result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// 检测手机号是否合法
        /// </summary>
        /// <param name="mobilephone">手机号</param>
        /// <returns>合法True，不合法False</returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 19:17
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static bool IsMobilephone(this string mobilephone)
        {
            return Regex.IsMatch(mobilephone ?? string.Empty, @"(^18\d{9}$)|(^13\d{9}$)|(^15\d{9}$)");
        }
    }
}