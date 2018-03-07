using System;
using Xunit;

namespace ThoughtHaven.Messages.Emails
{
    public class EmailContentTests
    {
        public class Constructor
        {
            public class TypeAndValueOverload
            {
                [Fact]
                public void NullType_Throws()
                {
                    Assert.Throws<ArgumentNullException>("type", () =>
                    {
                        new EmailContent(type: null, value: "value");
                    });
                }

                [Fact]
                public void EmptyType_Throws()
                {
                    Assert.Throws<ArgumentException>("type", () =>
                    {
                        new EmailContent(type: "", value: "value");
                    });
                }

                [Fact]
                public void WhiteSpaceType_Throws()
                {
                    Assert.Throws<ArgumentException>("type", () =>
                    {
                        new EmailContent(type: " ", value: "value");
                    });
                }

                [Fact]
                public void NullValue_Throws()
                {
                    Assert.Throws<ArgumentNullException>("value", () =>
                    {
                        new EmailContent(type: "text/plain", value: null);
                    });
                }

                [Fact]
                public void EmptyValue_Throws()
                {
                    Assert.Throws<ArgumentException>("value", () =>
                    {
                        new EmailContent(type: "text/plain", value: "");
                    });
                }

                [Fact]
                public void WhiteSpaceValue_Throws()
                {
                    Assert.Throws<ArgumentException>("value", () =>
                    {
                        new EmailContent(type: "text/plain", value: " ");
                    });
                }

                [Fact]
                public void ValidType_SetsType()
                {
                    var content = new EmailContent(type: "type", value: "value");

                    Assert.Equal("type", content.Type);
                }

                [Fact]
                public void ValidValue_SetsValue()
                {
                    var content = new EmailContent(type: "type", value: "value");

                    Assert.Equal("value", content.Value);
                }
            }
        }

        public class PlainTextMethod
        {
            public class ValueOverload
            {
                [Fact]
                public void ValidValue_SetsTypeToPlainText()
                {
                    var content = EmailContent.PlainText("value");

                    Assert.Equal("text/plain", content.Type);
                }

                [Fact]
                public void ValidValue_SetsValue()
                {
                    var content = EmailContent.PlainText("value");

                    Assert.Equal("value", content.Value);
                }

                [Fact]
                public void NullValue_Throws()
                {
                    Assert.Throws<ArgumentNullException>("value", () =>
                    {
                        EmailContent.PlainText(value: null);
                    });
                }

                [Fact]
                public void EmptyValue_Throws()
                {
                    Assert.Throws<ArgumentException>("value", () =>
                    {
                        EmailContent.PlainText(value: "");
                    });
                }

                [Fact]
                public void WhiteSpaceValue_Throws()
                {
                    Assert.Throws<ArgumentException>("value", () =>
                    {
                        EmailContent.PlainText(value: " ");
                    });
                }
            }
        }

        public class HtmlMethod
        {
            public class ValueOverload
            {
                [Fact]
                public void NullValue_Throws()
                {
                    Assert.Throws<ArgumentNullException>("value", () =>
                    {
                        EmailContent.Html(value: null);
                    });
                }

                [Fact]
                public void EmptyValue_Throws()
                {
                    Assert.Throws<ArgumentException>("value", () =>
                    {
                        EmailContent.Html(value: "");
                    });
                }

                [Fact]
                public void WhiteSpaceValue_Throws()
                {
                    Assert.Throws<ArgumentException>("value", () =>
                    {
                        EmailContent.Html(value: " ");
                    });
                }

                [Fact]
                public void ValidValue_SetsTypeToHtml()
                {
                    var content = EmailContent.Html("value");

                    Assert.Equal("text/html", content.Type);
                }

                [Fact]
                public void ValidValue_SetsValue()
                {
                    var content = EmailContent.Html("value");

                    Assert.Equal("value", content.Value);
                }
            }
        }
    }
}