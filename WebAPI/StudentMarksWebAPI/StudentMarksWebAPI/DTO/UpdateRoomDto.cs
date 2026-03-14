namespace StudentMarksAPI.DTO
{
    public class UpdateRoomDto
    {
        public int StudentId { get; set; }

        public int RoomNumber { get; set; }

        public string RoomType { get; set; }
    }
}