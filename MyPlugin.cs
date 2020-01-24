﻿using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Field_Seeker
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Field Seeker"),
        ExportMetadata("Description", "Simple little Plugin to search a field in all Entities by their Logical Name."),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAABHNCSVQICAgIfAhkiAAAAAFzUkdCAK7OHOkAAAAEZ0FNQQAAsY8L/GEFAAAACXBIWXMAABJ0AAASdAHeZh94AAAEUUlEQVRYR+1VXWgcVRg9d3ZmNpNNm2yTmM1Pm9XQtLGlMTSYuLE1MSUW0RfxpyCtKEhfhLyIgi8VBH3QB/EHQRG0fSmliApCaQwJ7UOlmIAtGn9K05jdRDdpupttspv9G8+d2exMFsQn2Zc9sNyZO/d+93znO/dbYRIoI5TCWDZUCFQIVAiUnUCxEV39MYm+4VnUNuuAhx9UclMFYis5zF1qR/vAn9BbVAz1G7jw/j3WZgnxYARGs4r2BgUznzdCPBmFv8ED4VFgqgzFcft2BWdeMhDazYkSFBXISx4bAvE8EF/OIRbOIhbJAnNZNPnJqE1DGgJTM5nCDiDMdaSAJKeGeqvsyRxJmwIrG8Cd28DyXeDmqomBU+v49hrjlaBIQCgC8PK3lscXHzXj5ytBTI/vwg9TQXhrFDw1YDAdgeUEcDtBlsTENE+R5IjBbionoTNzoWDkAQ2Ln9biwxe5j4REiwfHzqbtNS5s9YDG17zA3t067u/U0bPPi74eO7ORQwyUJcGsiRvzdiYXrjP1au5ZB54NFQiwbGAyNT4FAb+CVwZ1nHrCC5Mkksv2EjccAtxnbeZvB2tWipGDJCIVZ4ZnL6WsufGfSEDnniZZWxmAsGLIShTeiQM7pUp836ZgatFWbxPFkzSNC3L0QUBD94m/4Buah3p4Hl3H/7a+39uqQm1U8fTj1dCY9Tzr/0gPs6YYz/QXsrfAkDSwLokVkJY2pxlliVdLqqD8diuN907HMMl6Hj/ptyROkuT6Yg65JRORJZm2jT33aTh/MYUkg+yk089N8IGHhfZrhRVAbzfTpwoXf89j83/+2AEqIF98Hrx12YknoewJ6nj1RB2GDnpx5pM4UOOBwYWzk2248lUAYx80FpYCzx9iGZiFzydwM8pAsv6sd2udbUSJ/TSbnEvyWRQpEFRA4fJV+taNYgnqpJt3UUrWTlYiGFDR36Wjr9PJ7mHpdH4/fzWDRLIQnKaNp5yDkjJBliXN0It3N+c5Mmie6zJbBXAakVzkHQxbG7vaVfzyZZM9XQIxvISqDg0DHR6MU+aeDhXTb1QjRl+++XUavZ0e3LpjWtc6ytvRXCXwa8JE0C/Yayx/IktTSC+MhtiwNgnk+NU4soAMNz7a68Vno7UIr+RxeJ/bYOxHo3FEGBA0rUqjZdloZt7xYW/ALoN4meLXU1h+++4FDWE2oZOnsxjuJqE1mrlB4JvnnI7oIgAYRxeQZWBTXiFKKxsPGODGuXp0WFcN+HgshXdpvkiCh/OssdcNHHG1WPFaCsYONiMWPCXLJIvMgzfeVvkoSZho2ebckKIHpAIZHmbG+BIlGznGOJJEa71jsofoibkoZaS8YFesNZxgFpI04JpAirEgPSDHhTzbBxXjae7DJbZ4YPJ6GlVeBf0u45Vig9d04o8caljbNfahx1hzN76fpZcoiEeYCLUV8/tXuAiUB/9N8X9GhUCFQIVAmQkA/wAGk3fidgXHdAAAAABJRU5ErkJggg=="),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "Qk02SwAAAAAAADYAAAAoAAAAUAAAAFAAAAABABgAAAAAAABLAAB0EgAAdBIAAAAAAAAAAAAA/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////vj1+9/S++PX++TX++DT//79/////////////////////////////////////////////////////////////////////////vbw/ObU/enY/enY/enY/enY/enY/ejU/vbu/////////////////////////////////////unR/uzY/uzY/uzY/uzY/uzY/unR////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////+Mq14y0A5z4A5kAA5zsA8IJI86V69KJ186J19KN19KR19aV19aZ19aZ19J9o/fHq////////////////////////////////9Y078V0A8mQA8mUA82cA9GgA9GoA9GQA+api/vr2////////////////////////////////+m4A+n0A+n0A+n0A+n0A+n0A+ncA/L53/L54/L13/L13/L13/L13/Llt/ePG////////////////////////////////////////////////////////////////////////////////////////////+M+85j0A504D6U8F6FEF6EwA6EkA6UsA6U0A6k4A61AA6lEA7FMA61QA60YA/OfZ////////////////////////////////71cA8V8A8nAH83EH9HIH9HQG9XUH9HAA+atl/vfx////////////////////////////////+XgA+4gJ+4kJ+4kJ+4kJ+4kJ+4kJ+oIA+oIA+oIA+oIA+oIA+oIA+nkA/MuT////////////////////////////////////////////////////////////////////////////////////////////98+85DsA6EwE500D6E8E6FAF6VIF6lMF6lQF61YF61cF7FkF61oE7VwF608A+tW+/////////////////////////////////eve/vj08WAA8m8H83EH9HIH9HQG9G4A+axo/OHJ////////////////////////////////+XYA+YYJ+ogJ+4kJ+4kJ+4kJ+4kJ+4kJ+4kJ+4kJ+4kJ+4kJ+4kJ+oAA/c6Z////////////////////////////////////////////////////////////////////////////////////////////+M685TkA5ksE6EwE500D6E8E6FAF6VIF6lMF6lQF61YF6lcF7FkF61oE61EA97aO/////////////////////////////ena+cCW+suo8WMA8m4H828H83EH9HIH82wA+bR4/Nm6////////////////////////////////+HQA+oQJ+YYJ+ocJ+4kJ+4kJ+4kJ+4kJ+4kJ+4kJ+4kJ+4kJ+4kJ+oAA/c+c////////////////////////////////////////////////////////////////////////////////////////////+M684zgA50kE5ksE6EwE500D6E8E6EkA6EgA6EQA6EsA6UgA6U8A6koA6UEA8YVE////////////////////////////9ZpZ71YA72AA8WsH8WwH8m4H828H83EH82wA+Kxr+Kdh////////////////////////////////+HMA+IMJ+oQJ+YYJ+ocJ+4kJ+4kJ+4kJ+4kJ+4kJ+4kJ+4kJ+4kJ+oIA/L54/du0/vXs/uzX/uvV/dap/u7c////////////////////////////////////////////////////////////////////+M284zYA5UcE50kE5koE6EwE50YA8JJl8p50+trK8pdo+tzM8IhP+trJ/fTu/O3k////////////////////////////8XQd72MA8WgG8GkH8WsH8mwH8m4H828H8m0A95VF96FY+rmC////////////////////////////93EA+YEH+IMJ+oQJ+YYJ+ocJ+4kJ+n0A+nwA+nwA+nwA+oIA+4kJ+oEA/dqy/LRl/uHA/du1/t66/caH/dy2////////////////////////////////////////////////////////////////////+M284jQA5kYE5UcE50kE5kYA5DUA8ZJk8Ixb////7no//fDp9Kd+/fXx////////////////////////////////////7VIA72UF72cF8GgG8GkH8WsH8mwH8m0H828H8mwA82wA8VsA////////////////////////////928A94AH+YEH+IMJ+YQJ+YYJ+nsA/vr0/vn0/vjy/////L97+oIA+ocG+40R+5gp+5Mf+5Qg+5Mg+5Ui+pAY////////////////////////////////////////////////////////////////////+My84jMA5EUE5kYE5UMA63A5+tzP++TZ////////////////////////////////////////////////////////+9rF7VQA7mQG8GUG72YF8GgG8GkH8WsH8mwH8W0H828H8m8E8l0A////////////////////////////9WEA93IA93QA+HYA+HcA+XkA+W0A/v///////////////cOD+nYA+n4A+nwA+nwA+nwA+nwA+nwA+nsA+ngA////////////////////////////////////////////////////////////////////+My74TEA5UME5EQE5kYE5UMA4zIA7oJR////////////////////////////////////////////////////////9qp67FcA72IG7mMG72QE7loA714A8WkH8WoH8mwH8WwE83cW9IMm////////////////9ogm9oci9oIX/u7f/fDi/vDi/fDi/vDi/fDi/vfv+pgv+pcq+5Yl+5Me/MSF/vTp/vHi/vHi/vHi/vHi/vHi/vHi/vHj/vHh+5AY+5Yl+5Yl+5Yl+5Yl+44U/uzY////////////////////////////////////////98u74TAA5EED5UME5EQE5kYE5D4A74pd////////////////////////////////////////////////////////8Hox7VoA7WEG72EE7l4A+9e++cGb714A8WkH8WoH8WYA9qJh/////v///////////////Nu+/Nu+/Ny//eva+JQ3+J5G+Z9G+aBG+qFG+p9A+8SK/MOG/ePG/eTG/Lx0+5Ym+584+6I//KdH/KdH/KdH/KdH/KZG+6VE/efM/eC//eC//eC//eC//d25/vr1////////////////////////////////////////+djM4C4A5EAC40ED5UME5EQE5D0A74ld////////////////////////////////////////////////////////60wA7F0E7l8G7V8E7loA/////vj07lYA8GcF8WkH8WoH8WYA71QA+K91/////////////////////////Nm59GoA9ncA9ngA93oA93sA93MA/Niz/NKl/////////vz6/vv4/MB7+6lM+oAA+oQA+oQA+oQA+oMA+oAA////////////////////////////////////////////////////////////////////40QO4jkA4j4D5EAC40ED5UME4zsA7ohd/////////////////////////////////////////////////////OXY6koA7VwG7F0G7l4E604A/////fLq7VQA8GYG8GcF8WkG8GoH8WMA+baD/////////////////////////Nm89WwA9XoI93sI9n0I934I93EA/v///////////////////////dy4/Ldq+oMA+4kJ+4kJ+4kJ+4gG+oQA////////////////////////////////////////////////////////////////////3SAA4jsC4z0D4j4D5EAC40ED4zkA7odd////////////////////////////////////////////////////9rSP6k4A61oE7VwG61IA+L2Y/////fLp7VAA72QG8GYG8GcF8WkG8GEA+LWD/////////////////////////Nq89GsA9ngI9XoI93sI9nwI9m8A/v///////////////////////////bpw+oIA+4kJ+4kJ+4kJ+4gG+oQA////////////////////////////////////////////////////////////////////3SIA4joC4jsD4z0D4j4D5EAC4jgA74xm////////////////////////////////////////////////////8IJG6lEA7FkF61oE60wA/vHq/////fbw72UK7mAB72QG8GYG8GcF8F8A97SD/////////////////////////Nm79GkA9HcI9ngI9XkI93sI9m4A/v///////////////////////////blu+oIA+4kJ+4kJ+4kJ+4gG+oQA////////////////////////////////////////////////////////////////////2g8A3iYA4C4A4TsD4z0D4j4D4zwA51Ud7X9V7HtP7H1P7X1P7X5P7n5M7YJR////////////////////////6U4A6lQC6lcF7FkF6UoA/Ozi////////97uV7VcA72MG72QG8GYG714A+LSE////////////////////////+9m782gA9XUH9HcI9ngI9XkI9WwA/v//////////////////////////+7hu+oEA+4kJ+4kJ+4kJ+4gG+oQA/////////////////////////////////////////////fXz3jMI4kUb4kYb4kcc4T0N/O7p/PHt8rCb4C4A4TsD4zwD4j4D4zwA4jkA4zoA4zwA5D0A5T8A5D4A5T8A/////////////////////fXx5z8A6lQF61YF6lcF6kgA/Ovi////////9rOJ7FUA7mEG72MG7mQG710A97B+////////////////////////+97G82YA83QG9XUH9HYI9ngI9GoA/v//////////////////////////+7dv+X8A+ocJ+4kJ+4kJ+4cG+oMA////////////////////////////////////////////////////////////////////2QwA3SMA3ysA4TgD4joD4TsD4zwD4j4D4z8D40EC5EID5UME5UUE5D0A8Zlz////////////////////9sGm50QA6lMF6lQF61YF6EYA/Ovi////////9bKJ7FMA7mAG7mEG72MG7l8A84pB////////////////////////9pVI8msA9HIH83MG9XUH9HYI810A/v//////////////////////////+7dw+X4A+YYJ+ocJ+4kI+oYE+oMA////////////////////////////////////////////////////////////////////2xsA4DQB4DUC4TcD4DgD4jkD4TsD4jwD4j4D4z8D40AC5EID5UME4zwA74he////////////////////8I5e50gA6VEF6U8A50AA5jEA/fj0////////9Kh76UEA7V4G7l8G7mEG72ED7lwA////////////////////////8FcA828H83EH9HIH83MG9GkA/ejV////////////////////////+8aR+HIA+IMJ+YQJ+YYJ+ocI+n8A////////////////////////////////////////////////////////////////////////2xoA3zIB4DQB4DUC4TYD4DgD4DAA3y0A4C8A4TEA4TIA4jMA4jUA4i4A7HhJ////////////////////6VgT50sA6EwA62sp////////7F4R6EIA////////////60sA7V4G7mAG7mEG7VAA/vXv////////////////////8FoA8m4H828H8nAH9HIH8mYA/enX/////////////////////////Myd93cA+YEH+IMJ+YQJ+YUH+X4A////////////////////////////////////////////////////////////////////////2hgA3zEB3zIC4DQB3zUC3ywA7Y1u8qiQ8aWL8qaL8qaL8qeL8qeL8qSH9sKt////////////////////5DUA500D6E0C6VQL74RN73xB86B0+tfE/////vv573cx61UA7VwG7V4G7l8G7FUA+cin////////////////////71kA8mwH8m0H828H8nAH82UA/OfV/////////////////////////Mud93UA94AH+IEH+IMJ+YMG+YMD////////////////////////////////////////////////////////////////////////2RYA3i8B3zEC3zIC4DQB3SMA+tzU////////////////////////////////////////////////+NG/5DoA50sE6E0D6E0C6EkA5joA++TY////////////6ksA61gC7FsF7VwG7V4G7VcA9Jpg////////////////////71cA8WoH8mwH8W0H828H8WMA/OfV////////////////////////+8iY9nQA+H4I94AH+IEH+IAE+YsX////////////////////////////////////////////////////////////////////////2RQA3S0B3i8C3zAC3zIC3SEA+NPI////////////////////////////////////////////////8Zt35T4A5koE50sE6E0D6E4D5j0A////////////////73w86lIA7FkE7FsF7VwG7FsA72sY////////////////////7lUA8WkH8WoH8mwH8W0H8mEA/OfV////////////////////////+ryC9nMA9n0I+H4I938I+H0A+pgz////////////////////////////////////////////////////////////////////////2BMA3SwB3i0C3i8C3zAC3B8A+NPI////////////////////////////////////////////////6WUu5UEA5kgE50oE50sE50gA6mAe////////////////9Kh+6UwA61gF7FkE7FsE7VwF6koA////////////////////7lMA8GcF8WkH8GoH8mwH8F8A/ObV////////////////////////+KJU9XQA93sI9n0I934I93oA+qpa////////////////////////////////////////////////////////////////////////2BEA3CoB3SwC3i0C3i8C3B4A99LI////////////////////////////////////////////////4jIA5UUC5UcE5kgE50oE5kIA8I9h////////////////+dTA6EYA6lYF61gF7FkE7FsE600A+tnE////////////////7VIA8GYG8GcF8WkG8GoH8F4A/ObV////////////////////////9HMA9ncF9XoI93sI9n0I93UA+8SN////////////////////////////////////////////////////////////////////////1w8A3CkB3SoC3SwC3i0C2xwA99LI////////////////////////////////////////////+uPa4i8A5EQE5UUE5kcE5kgE5TwA9r2j////////////////////5z8A6lUE61YF61gF7FkE6lEA9al8////////////////7VAA72QG8GYG8GcF8WkG71wA/OXV////////////////////+9Ku9GkA9XcI9ngI9XkI93sI9m8A/efR////////////////////////////////////////////////////////////////////////1w4A2ycA3CkC3SoC3SwC2xoA+d3W////////////////////////////////////////////86uQ4TQA5EIE5EQE5UUE5kcE4zQA/O3m////////////////////6VQH6VEB6lUF61YF61gF61QA73kz////////////////7E4A72MG72QG8GYG8GcF71oA/e7j/////////////////NvB82YA9HMF9XUH9HcI9ngI9XgG9XEA////////////////////////////////////////////////////////////////////////////1gwA2yYA2ycB3CkC3SoC2yQA52lK6nxg6npd6ntd6nxd631d635e7H9e63xZ8Jp/////////6nNI4zgA40EC5EID5EQE5UQC5DgA////////////////////////74JL6EsA6lMF6lUF61YF6lYD6ksA////////////////600A7mEG72MG72QG8GYG72EA9ptZ9qhu9qJj9ZJH8m0E8WIA83AF9HIH9HQG9XUH9HYI9XEA+alh////////////////////////////////////////////////////////////////////////////1goA2iQA2yYA3CcA3CkC3SoC2yQA3CMA3CQA3SYA3ScA3ikA3ioA3iwA3icA5lgr////////4jkA4jwA5D8C40EC5EIE5D4A6WMt////////////////////////9a6N50QA6VIF6lMF6lUF61YF6EYA/Orf////////////60sA7WAG7mEG72MG72QG8GUG72EA8GAA8GIA8WYA8WsD8m4G828H83EH9HIH83MG9XQG82UA/v38////////////////////////////////////////////////////////////////////////////1QgA2iMA2iQB2yYA3CcA3CkC3SoC3CsC3i0C3S4C3jAC3jEC3zIB4DQB3y8A5140/////fj13iQA4zwC4j4D4z8D40AC4zgA8JNv////////////////////////+tzN5j4A6FAF6VIF6lMF6lQF6UoA9riW////////////6kkA7V4G7mAG7mEG72IG7mQG8GUG72cF8WgG8GkH8WsH8WwH8m4H828H83EH9HIG8mIA+sCP////////////////////////////////////////////////////////////////////////////////1QcA2SEA2iMB2yQB2yYA3CcA3CkC3SoC3CsC3i0C3S4C3jAC3jEC3zIB3y0A5l00////9b2r3yoA4TsD4zwD4j4D4z8D4TEA9sOv////////////////////////////5TgA6E4E6VAF6VEF6lMF6U0A8IdO////////////6kcA7F0G7V4G7mAG7mEG72IG7mQG8GUG72cF8GgG8GkH8WsH8mwH8m4G8mwC8V0A+Kxt////////////////////////////////////////////////////////////////////////////////////0wAA2BkA2BoA2RwA2R0A2h8A2iAA2iEA3CMA2yQA3CYA3CcA3SkA3SoA3SUA5Vct////635c3igA4TQA4TUA4TYA4jgA3yUA/fTx////////////////////////////6FMO5kUA50kA6EsA6EwA6UwA6U8A////////////6EEA7FYA7FcA7FkA7VoA7VwA7l0A7l8A72AA72IA8GMA8GIA8GEA8FsA8nEN+9vC////////////////////////////////////////////////////////////////////////////////////////3DYd4Eoy4Usy4Uwy4U0y4U4y4lAy4lEy4lIz41Mz41Qz5FUz5FYz5Vgz5FQt6ntc////52U/5FEk5VYp5lcp5lgp51ko5VId////////////////////////////////8JVs6mEi62gq7Gkq7Gor7Gwq61wS/vv5////////7Wof73o18Hs18Hw28H028X428YA28oA28YI28oM184c79ZhV+LaH/Ona////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////"),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class MyPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MyPluginControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public MyPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}