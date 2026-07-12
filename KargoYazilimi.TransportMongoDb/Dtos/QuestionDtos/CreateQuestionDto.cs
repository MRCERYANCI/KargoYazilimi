namespace KargoYazilimi.TransportMongoDb.Dtos.QuestionDtos
{
    public class CreateQuestionDto
    {
        public string QuestionTitle { get; set; }
        public string Answer { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
    }
}
