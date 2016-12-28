<%@ WebHandler Language="C#" Class="ImageResizeHandler" %>

using System;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
public class ImageResizeHandler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        //get image path from querystring
        string imgPath = context.Request.QueryString["imgPath"];
        //get image width to be resized from querystring
        string imgwidth = context.Request.QueryString["width"];
        //get image height to be resized from querystring
        string imgHeight = context.Request.QueryString["height"];
        //check that height and width is passed as querystring. then only image resizing will happen
        if (imgPath != string.Empty && imgHeight != string.Empty && imgwidth != string.Empty && (imgHeight != null && imgwidth != null))
        {
            if (!System.Web.UI.WebControls.Unit.Parse(imgwidth).IsEmpty && !System.Web.UI.WebControls.Unit.Parse(imgHeight).IsEmpty)
            {

            
                
                
                
                //create callback handler
                System.Drawing.Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                //creat BitMap object from image path passed in querystring

                WebRequest req = WebRequest.Create(imgPath);

                // load a bitmap from a Web response stream
                WebResponse resp = req.GetResponse();
                Stream s = resp.GetResponseStream();

                // Load the image from the stream
                Bitmap myBitmap = new Bitmap(s);

                System.Web.UI.WebControls.Unit widthUnit;
                System.Web.UI.WebControls.Unit heightUnit;
                if (Convert.ToInt32(myBitmap.Width) <= Convert.ToInt32(imgwidth))
                    widthUnit = System.Web.UI.WebControls.Unit.Parse(myBitmap.Width.ToString());
                else
                    widthUnit = System.Web.UI.WebControls.Unit.Parse(imgwidth);
                if (Convert.ToInt32(myBitmap.Height) <= Convert.ToInt32(imgHeight))
                    heightUnit = System.Web.UI.WebControls.Unit.Parse(myBitmap.Height.ToString());
                else
                    heightUnit = System.Web.UI.WebControls.Unit.Parse(imgHeight);

                //Bitmap myBitmap = new Bitmap(imgPath);
                //create unit object for height and width. This is to convert parameter passed in differen unit like pixel, inch into generic unit.
                // System.Web.UI.WebControls.Unit widthUnit = System.Web.UI.WebControls.Unit.Parse(imgwidth);
                //System.Web.UI.WebControls.Unit heightUnit = System.Web.UI.WebControls.Unit.Parse(imgHeight);
                //Resize actual image using width and height paramters passed in querystring
                Image myThumbnail = myBitmap.GetThumbnailImage(Convert.ToInt16(widthUnit.Value), Convert.ToInt16(heightUnit.Value), myCallback, IntPtr.Zero);
                //Create memory stream and save resized image into memory stream
                MemoryStream objMemoryStream = new MemoryStream();
                myThumbnail.Save(objMemoryStream, System.Drawing.Imaging.ImageFormat.Png);
                //Declare byte array of size memory stream and read memory stream data into array
                byte[] imageData = new byte[objMemoryStream.Length];
                objMemoryStream.Position = 0;
                objMemoryStream.Read(imageData, 0, (int)objMemoryStream.Length);


                //var byteArray = resp.GetResponseStream();// new StreamReader(imgPath).BaseStream;
                //var image = Image.FromStream(byteArray);
                //var newHeight2 = Convert.ToInt32(Convert.ToInt32(imgwidth) * (1.0000000 * image.Height / image.Width));
                //var thumbnail = new Bitmap(Convert.ToInt16(imgwidth), newHeight2);
                //var graphic = Graphics.FromImage(thumbnail);

                //graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                //graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //graphic.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                //graphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                //graphic.DrawImage(image, 0, 0, Convert.ToInt16(imgwidth), newHeight2);
                //thumbnail.Save(objMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                //byte[] imageDataNew = new byte[objMemoryStream.Length];
                //objMemoryStream.Position = 0;
                //objMemoryStream.Read(imageDataNew, 0, (int)objMemoryStream.Length);
                
                //return thumbnail;
                
                
                
                
                
                //send contents of byte array as response to client (browser)
                context.Response.BinaryWrite(imageData);
            }
        }
        else
        {
            //if width and height was not passed as querystring, then send image as it is from path provided.
            context.Response.WriteFile(context.Server.MapPath(imgPath));
        }
    }


    public bool ThumbnailCallback()
    {
        return false;
    }
    public bool IsReusable
    {
        get
        {
            return true;
        }
    }

}