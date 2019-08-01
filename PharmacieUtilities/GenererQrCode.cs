using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace PharmacieUtilities
{
    public class GenererQrCode
    {
        public void QRCode(PictureBox pic_box, string data)
        {

            try
            {
                ThoughtWorks.QRCode.Codec.QRCodeEncoder objQRCode = new ThoughtWorks.QRCode.Codec.QRCodeEncoder();
                Image imgImage;
                objQRCode.QRCodeEncodeMode = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ENCODE_MODE.BYTE;
                objQRCode.QRCodeScale = 4;
                objQRCode.QRCodeVersion = 7;
                objQRCode.QRCodeErrorCorrect = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ERROR_CORRECTION.L;
                imgImage = objQRCode.Encode(data);
                pic_box.Image = imgImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
