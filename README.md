# qrcp

⚡ Transfer files over wifi from your computer to your mobile device by scanning a QR code. (Got insprited by [claudiodangelis/qrcp](https://github.com/claudiodangelis/qrcp))

## How does it work?
![Menu](images/menu.png)

![Receive](images/receive.png)

![Send](images/send.png)

`qrcp` binds a web server to the address of your Wi-Fi network interface on a random port and creates a handler for it. The default handler serves the content and exits the program when the transfer is complete. When used to receive files, `qrcp` serves an upload page and handles the transfer.