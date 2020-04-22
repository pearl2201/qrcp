using QRCoder;

public class QrServices
{

    public QrServices()
    {
        
    }
    public string GenerateQrCode(string input)
    {
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode("The text which should be encoded.", QRCodeGenerator.ECCLevel.Q);
        SvgQRCode qrCode = new SvgQRCode(qrCodeData);
        string qrCodeAsSvg = qrCode.GetGraphic(20);
        return qrCodeAsSvg;
    }
}