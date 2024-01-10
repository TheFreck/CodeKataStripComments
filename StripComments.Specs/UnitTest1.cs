using Machine.Specifications;
using System.ComponentModel.DataAnnotations;

namespace StripComments.Specs
{
    public class When_Removing_Comments_From_A_Single_Line_Of_Text
    {
        Establish context = () => {
            textInput = "this should appear # but pound should not ! but exclamation should not";
            commentFlags = new[] { "#", "!" };
            expected = "this should appear";
        };

        Because of = () => output = CommentStripper.RemoveComments(textInput, commentFlags);

        It Should_Return_Text_Without_Comments = () => output.ShouldEqual(expected);

        private static string textInput;
        private static string output;
        private static string[] commentFlags;
        private static string expected;
    }

    public class When_Removing_Comments_From_All_Lines_Of_Text
    {
        Establish context = () =>
        {
            textInput = "apples, pears # and bananas\ngrapes\nbananas !apples";
            commentFlags = new[] { "#", "!" };
            expected = "apples, pears\ngrapes\nbananas";
        };

        Because of = () => textOutput = CommentStripper.StripComments(textInput, commentFlags);

        It Should_Return_The_Original_Text_Without_Any_Comments = () => textOutput.ShouldEqual(expected);

        private static string textInput;
        private static string[] commentFlags;
        private static string expected;
        private static string textOutput;
    }
}