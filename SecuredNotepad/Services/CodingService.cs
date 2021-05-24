using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace SecuredNotepad.Services
{
    public class CodingService
    {
        public CodingService()
        {
        }

        public static byte[] StringFromUserRSAString(string s_characters)
        {

            s_characters = s_characters.Replace("A", "^");
            s_characters = s_characters.Replace("B", "^");
            s_characters = s_characters.Replace("C", "^");
            s_characters = s_characters.Replace("D", "^");
            s_characters = s_characters.Replace("E", "^");
            s_characters = s_characters.Replace("F", "^");
            s_characters = s_characters.Replace("G", "^");
            s_characters = s_characters.Replace("H", "^");
            s_characters = s_characters.Replace("I", "^");
            s_characters = s_characters.Replace("J", "^");
            s_characters = s_characters.Replace("K", "^");
            s_characters = s_characters.Replace("L", "^");
            s_characters = s_characters.Replace("M", "^");
            s_characters = s_characters.Replace("N", "^");
            s_characters = s_characters.Replace("O", "^");
            s_characters = s_characters.Replace("P", "^");
            s_characters = s_characters.Replace("Q", "^");
            s_characters = s_characters.Replace("R", "^");
            s_characters = s_characters.Replace("S", "^");
            s_characters = s_characters.Replace("T", "^");
            s_characters = s_characters.Replace("U", "^");
            s_characters = s_characters.Replace("V", "^");
            s_characters = s_characters.Replace("W", "^");
            s_characters = s_characters.Replace("X", "^");
            s_characters = s_characters.Replace("Y", "^");
            s_characters = s_characters.Replace("Z", "^");


            char[] cr = { '^' };


            string[] ss = s_characters.Split(cr);

            byte[] RSAData = new byte[ss.Length];
            try
            {
                for (int i = 0; i < ss.Length; i++)
                {
                    RSAData[i] = System.Convert.ToByte(ss[i]);
                }
            }
            catch
            {
            }

            return RSAData;

        }


        private static string GiveRndCharacter(int start)
        {
            char ch_znak;

            Random rnd = new Random(start);

            ch_znak = (char)rnd.Next(65, 90);

            return ch_znak.ToString();

        }

        public static string UserRSAStringFromString(byte[] BytesToCode)
        {
            string result = "";

            for (int i = 0; i < BytesToCode.Length; i++)
            {
                result += BytesToCode[i].ToString() + GiveRndCharacter(i);
            }

            result = result.Substring(0, result.Length - 1);

            return result;
        }

        private static string ImportKey()
        {
            string abKey = "7S2G0T0H0U164I0V0J82W83K65X50L0Y4M0B0O1C0P1D0Q131E84R121F70S175G15T197H33U29I15V176J99X61L222Y252M119A134N59B121O232C114P212D227Q255E115R246F184S22H199U158I133V249J25W245K28X39L16Y131M94A164N158B215O208C7P245E255R78F126S249G24T111H32U120I186V123J142W196K2X54L21Y18N60B75O135C183P192D122Q158E60R151F248S24G114T238H195U33I165V20K152X105L26Y1M112A226N239B243O50C252P177D205Q127E53R14F164T35H33U129I250V49J155W18K239X76L38Y234M203A42N164B113O218C138Q102E141R242F108S112G183T213H133U66I71V183J19W177K125X141L61A188N109B86O135C227P197D255Q23E82R5F78S254G93T28H5U254I56W45K222X193L209Y166M246A20N161B149O52C233P245D216Q12E212R17G241T189H10U220I211V255J205W154K203X186L147Y170M30A56N236B229O39D144Q216E136R200F21S0G178T94H51U206I95V94J46W103K231X175M64A130N148B110O63C216P199D128Q110E104R249F178S58G10T174H17U70J239W84K163X154L253Y113M183A50N72B25O10C237P3D41Q72E187S37G163T119H155U99I28V85J90W168K216X98L61Y63M97A0N198B46P186D33Q44E135R107F46S64G113T206H104U218I63V208J45W159K160Y253M227A58N154B220O165C173P212D207Q185E154R104F205S92G0T132H97V143J245W47K136X170L76Y162M236A204N30B250O147C111P106D125Q245F162S117G247T38H176U133I112V77J57W5K88X122L190Y200M140A81N112C137P57D82Q251E146R124F181S65G54T167H102U219I39V128J37W133L19Y216M26A181N6B14O139C154P184D102Q189E16R28F119S145G191T197I221V171J140W195K229X167L12Y36M212A51N63B201O75C40P133D217R185F252S71G91T36H73U82I240V187J9W22K132X124L173Y35M41A188O200C17P226D4Q96E249R87F214S93G174T31H185U252I79V58J69X160L236Y23M125A190N213B184O110C2P42D74Q170E248R166F66S34G215U180I35V237J255W148K178X184L24Y186M200A187N155B148O172C50P141E138R153F194S233G69T214H58U103I122V198J171W8K169X202L61Y235M252B155O169C42P92D67Q223E100R209F195S217G32T152H181U56I99V196K76X188L43Y102M44A240N175B146O134C36P114D161Q59E58R80F36S48H158U77I227V179J0W5K14X195L62Y2M78A160N91B130O80C162Q75E30R121F93S190G25T198H213U149I3V69J92W201K37X101L208Y166N208B111O110C239P126D174Q40E61R0F178S157G46T16H73U183I144W30K71X30L60Y218M124A27N39B160O53C153P177D57Q79E0R201F55T50H108U201I48V215J156W252K38X23L0Y228M109A195N128B78O249D28Q213E201R15F151S49G14T71H194U203I178V213J99W106K206X69L42A43N157B130";
            return abKey;
        }
        public static string RSAEncrypt(string text)
        {
            string sTextCoded = "";
            try
            {
                UnicodeEncoding ByteConverterU = new UnicodeEncoding();
                byte[] ByteStr = Encoding.Convert(Encoding.Unicode, Encoding.Default, ByteConverterU.GetBytes(text));

                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);
                byte[] bkey = StringFromUserRSAString(ImportKey());
                rsa.ImportCspBlob(bkey);

                ByteStr = rsa.Encrypt(ByteStr, false);
                sTextCoded = Convert.ToBase64String(ByteStr);
                rsa = null;
            }
            catch (CryptographicException cex)
            {
                Debug.WriteLine(cex);
            }

            return sTextCoded;
        }
        public static string RSADecrypt(string text)
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);
            byte[] ByteStrDecoded = null;
            try
            {

                byte[] bkey = StringFromUserRSAString(ImportKey());
                rsa.ImportCspBlob(bkey);

                ByteStrDecoded = Convert.FromBase64String(text);
            }
            catch
            {
            }
            text = "";
            try
            {
                ByteStrDecoded = rsa.Decrypt(ByteStrDecoded, false);
                byte[] ByteStr = Encoding.Convert(Encoding.Default, Encoding.Unicode, ByteStrDecoded);
                text = ByteConverter.GetString(ByteStr, 0, ByteStr.Length);
            }
            catch
            {
            }
            return text;
        }
    }

}
