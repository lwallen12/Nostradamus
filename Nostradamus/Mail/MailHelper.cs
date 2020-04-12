using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.Mail
{
    public static class MailHelper
    {
        static readonly string resetSubject = "iNostradamus Password Reset (via Amazon SES)";

        // The email body for recipients with non-HTML email clients.
        static readonly string textBody = "Amazon SES Test (.NET)\r\n"
                                        + "This email was sent through Amazon SES "
                                        + "using the AWS SDK for .NET.";

        public static void sendReset(string senderAddress, string receiverAddress, string resetToken) {
            using (var client = new AmazonSimpleEmailServiceClient(RegionEndpoint.USEast1))
            {

                var resetHTMLBody = @"<html>
                    <head></head>
                    <body>
                      <h1>iNostradamus Password Reset (via Amazon SES)</h1>
                      <p>Use the token below to reset your password:</p> 
                            
                      <p><b>" + resetToken + @"</b></p>     

                       <p> Access the page here: 
                        <a href='http://localhost:4200/'>iNostradmus Sign in</a> .</p>
                    </body>
                    </html>";

        var sendRequest = new SendEmailRequest
                {
                    Source = senderAddress,
                    Destination = new Destination
                    {
                        ToAddresses =
                        new List<string> { receiverAddress, "a.allenwill@gmail.com" }
                    },
                    Message = new Message
                    {
                        Subject = new Content(resetSubject),
                        Body = new Body
                        {
                            Html = new Content
                            {
                                Charset = "UTF-8",
                                Data = resetHTMLBody
                            },
                            Text = new Content
                            {
                                Charset = "UTF-8",
                                Data = textBody
                            }
                        }
                    },
                    // If you are not using a configuration set, comment
                    // or remove the following line 
                    //ConfigurationSetName = configSet
                };
                try
                {
                    var response = client.SendEmailAsync(sendRequest);
                }
                catch (Exception ex)
                {
                    var response = ex.Message;
                }
            }
    
        }

        public static void sendSignUpAlert(string newUser)
        {
            using (var client = new AmazonSimpleEmailServiceClient(RegionEndpoint.USEast1))
            {

                var resetHTMLBody = @"<html>
                    <head></head>
                    <body>
                      <h1>New Sign Up</h1>
                      <p>This user signed up:</p> 
                            
                      <p><b>" + newUser + @"</b></p>     

                    </body>
                    </html>";

                var sendRequest = new SendEmailRequest
                {
                    Source = "a.allenwill@gmail.com",
                    Destination = new Destination
                    {
                        ToAddresses =
                                new List<string> { "a.allenwill@gmail.com" }
                    },
                    Message = new Message
                    {
                        Subject = new Content(resetSubject),
                        Body = new Body
                        {
                            Html = new Content
                            {
                                Charset = "UTF-8",
                                Data = resetHTMLBody
                            },
                            Text = new Content
                            {
                                Charset = "UTF-8",
                                Data = textBody
                            }
                        }
                    },
                    // If you are not using a configuration set, comment
                    // or remove the following line 
                    //ConfigurationSetName = configSet
                };
                try
                {
                    var response = client.SendEmailAsync(sendRequest);
                }
                catch (Exception ex)
                {
                    var response = ex.Message;
                }
            }

        }

    }
}
