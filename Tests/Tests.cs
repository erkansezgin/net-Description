namespace DescriptionLibrary.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void ExistingConstructorWithoutParameters()
        {
            // Arrange
            var expected = "Class constructor description.";

            // Act
            var actual = typeof(Class).ConstructorDescription();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExistingConstructorWithParameters()
        {
            // Arrange
            var expected = "Another class constructor description.";

            // Act
            var actual = typeof(Class).ConstructorDescription(new[] { typeof(int), typeof(string), });

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExistingEnum()
        {
            // Arrange
            var expected = "Enum value description.";

            // Act
            var actual = Enum.Value.Description();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExistingEvent()
        {
            // Arrange
            var expected = "Class event description.";

            // Act
            var actual = typeof(Class).EventDescription("Event");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExistingField()
        {
            // Arrange
            var expected = "Class field description.";

            // Act
            var actual = typeof(Class).FieldDescription("Field");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExistingMethod()
        {
            // Arrange
            var expected = "Class method description.";

            // Act
            var actual = typeof(Class).MethodDescription("Method");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExistingParameter()
        {
            // Arrange
            var expected1 = "Class generic parameter description.";
            var expected2 = "Class parameter description.";

            // Act
            var actual1 = typeof(Class).ParameterDescription("Method", "_1");
            var actual2 = typeof(Class).ParameterDescription("Method", "_2");

            // Assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        [TestMethod]
        public void ExistingProperty()
        {
            // Arrange
            var expected = "Class property description.";

            // Act
            var actual = typeof(Class).PropertyDescription("Property");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExistingReturn()
        {
            // Arrange
            var expected = "Class method return description.";

            // Act
            var actual = typeof(Class).ReturnDescription("Method");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExistingType()
        {
            // Arrange
            var expected1 = "Class description.";
            var expected2 = "Enum description.";

            // Act
            var actual1 = typeof(Class).Description();
            var actual2 = typeof(Enum).Description();

            // Assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        [TestMethod]
        public void NonExistingConstructor()
        {
            // Act
            var value = typeof(Class).ConstructorDescription(new[] { typeof(byte) });

            // Assert
            Assert.IsNull(value);
        }

        [TestMethod]
        public void NonExistingEnum()
        {
            // Act
            var value = ((Enum)1).Description();

            // Assert
            Assert.IsNull(value);
        }

        [TestMethod]
        public void NonExistingEvent()
        {
            // Act
            var value = typeof(Class).EventDescription("NotExisting");

            // Assert
            Assert.IsNull(value);
        }

        [TestMethod]
        public void NonExistingField()
        {
            // Act
            var value = typeof(Class).FieldDescription("NotExisting");

            // Assert
            Assert.IsNull(value);
        }

        [TestMethod]
        public void NonExistingMethod()
        {
            // Act
            var value = typeof(Class).MethodDescription("NotExisting");

            // Assert
            Assert.IsNull(value);
        }
        [TestMethod]
        public void NonExistingParameter()
        {
            // Act
            var value = typeof(Class).ParameterDescription("Method", "unexisting");

            // Assert
            Assert.IsNull(value);
        }

        [TestMethod]
        public void NonExistingProperty()
        {
            // Act
            var value = typeof(Class).PropertyDescription("NotExisting");

            // Assert
            Assert.IsNull(value);
        }

        [TestMethod]
        public void NonExistingReturn()
        {
            // Act
            var value = typeof(Class).ReturnDescription("NotExisting");

            // Assert
            Assert.IsNull(value);
        }

        [TestMethod]
        public void NonExistingType()
        {
            // Act
            var value = new { }.GetType().Description();

            // Assert
            Assert.IsNull(value);
        }
    }
}
