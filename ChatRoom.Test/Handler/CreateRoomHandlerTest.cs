using ChatRoom.Domain.CommandHandlers.Room;
using ChatRoom.Domain.Commands.Room;
using ChatRoom.Domain.Interfaces;
using ChatRoom.Domain.Models;
using NSubstitute;

namespace ChatRoom.Test.Handler
{
    public class CreateRoomHandlerTest
    {
        private readonly IRepository<Room> _repository;
        private readonly IUnitOfWork _uow;

        public CreateRoomHandlerTest()
        {
            _repository = Substitute.For<IRepository<Room>>();
            _uow = Substitute.For<IUnitOfWork>();
        }

        [Theory]
        [MemberData(nameof(GetValidData))]
        public async void ShouldCreate(string userId, string name, string description)
        {
            var command = new CreateRoomCommand(userId, name, description);
            var handler = new CreateRoomHandler(_uow, _repository);
            var result = await handler.Handle(command, CancellationToken.None);
            Assert.True(result.IsValid);
        }

        [Theory]
        [MemberData(nameof(GetInvalidData))]
        public async void ShouldNotCreate(string userId, string name, string description)
        {
            var command = new CreateRoomCommand(userId, name, description);
            var handler = new CreateRoomHandler(_uow, _repository);
            var result = await handler.Handle(command, CancellationToken.None);
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
