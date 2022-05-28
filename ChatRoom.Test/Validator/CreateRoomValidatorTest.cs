using ChatRoom.Domain.Commands.Room;
using ChatRoom.Domain.Commands.Room.Validators;

namespace ChatRoom.Test.Validator
{
    public class CreateRoomValidatorTest
    {
        [Theory]
        [MemberData(nameof(GetValidData))]
        public void ShouldBeValidCommand(string userId, string name, string description)
        {
            var command = new CreateRoomCommand(userId, name, description);
            var validator = new CreateRoomValidator();
            var result = validator.Validate(command);
            Assert.True(result.IsValid);
        }

        [Theory]
        [MemberData(nameof(GetInvalidData))]
        public void ShouldBeInvalidCommand(string userId, string name, string description)
        {
            var command = new CreateRoomCommand(userId, name, description);
            var validator = new CreateRoomValidator();
            var result = validator.Validate(command);
            Assert.False(result.IsValid);
        }

        public static IEnumerable<object[]> GetValidData()
        {
            var data = new List<object[]>();

            data.Add(new object[]
                {
                    "useremail@domain.com",
                    "Chat room name",
                    "Description"
                });

            data.Add(new object[]
                {
                    "useremail@domain.com",
                    "Chat room name",
                    null
                });

            data.Add(new object[]
                {
                    "useremail@domain.com",
                    "Chat room name",
                    string.Empty
                });

            return data;
        }

        public static IEnumerable<object[]> GetInvalidData()
        {
            var data = new List<object[]>();

            data.Add(new object[]
                {
                    null,
                    "Name",
                    "Description"
                });

            data.Add(new object[]
               {
                    string.Empty,
                    "Name",
                    "Description"
               });

            data.Add(new object[]
                {
                    "useremail@domain.com",
                    null,
                    "Description"
                });

            data.Add(new object[]
                {
                    "useremail@domain.com",
                    string.Empty,
                    "Description"
                });

            data.Add(new object[]
                {
                    "useremailuseremailuseremailuseremailuseremailuseremailuseremailuseremailuseremailuseremailuseremailuseremailuseremailuseremailuseremailuseremailuseremailuseremailuseremailuseremailuseremailuseremailuseremailuseremailuseremailuseremailuseremailus@domain.com",
                    "Name",
                    "Description"
                });

            data.Add(new object[]
                {
                    "useremail@domain.com",
                    "NameNameNameNameNameNameNameNameNameNameNameNameNam",
                    "Description"
                });

            data.Add(new object[]
                {
                    "useremail@domain.com",
                    "Name",
                    "DescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescri"
                });

            return data;
        }
    }
}
