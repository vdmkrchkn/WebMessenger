using app.Controllers;
using app.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace app.Tests
{
    [TestClass]
    public class MessagesControllerTests
    {
        [TestMethod]
        public void GetMessages_NoHours_ResponseIsNull()
        {
            // Arrange
            var mock = new Mock<IMessageService>();
            mock.Setup(ms => ms.GetMessages(null, null))
                .Returns< IEnumerable<Models.ViewModels.MessageView>>(null);
            var messagesController = new MessagesController(mock.Object);

            // Act
            var res = messagesController.Get(null);

            // Assert
            Assert.IsNull(res);
        }

        [TestMethod]
        public void GetMessages_SomeHours_ResponseIsNull()
        {
            // Arrange
            byte hours = 2;
            var mock = new Mock<IMessageService>();
            mock.Setup(ms => ms.GetMessages(hours))
                .Returns<IEnumerable<Models.ViewModels.MessageView>>(null);
            MessagesController messagesController = new MessagesController(mock.Object);            

            // Act
            var res = messagesController.Get(hours);

            // Assert
            Assert.IsNull(res);
        }

        [TestMethod]
        public void AddMessage_NoMessage_BadRequestResult()
        {
            // Arrange
            MessagesController messagesController = new MessagesController(null);            

            // Act
            var res = messagesController.Add(null);

            // Assert            
            Assert.IsInstanceOfType(res, typeof(Microsoft.AspNetCore.Mvc.BadRequestResult));
        }

        [TestMethod]
        public void AddMessage_SomeMessage_OkResult()
        {
            // Arrange
            var mock = new Mock<IMessageService>();
            var messagesController = new MessagesController(mock.Object);
            var mockMessage = new Models.ViewModels.MessageView();

            // Act
            var res = messagesController.Add(mockMessage);            

            // Assert            
            Assert.IsInstanceOfType(res, typeof(Microsoft.AspNetCore.Mvc.OkResult));
            mock.Verify(ms => ms.Add(mockMessage));
        }
    }
}
