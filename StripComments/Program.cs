using StripComments;

static void Main(string[] args)
{
    CommentStripper.StripComments("text", new string[]{ "#","!"});
}