using System;
using System.Collections.Generic;

namespace CSharpNote.Data.CSharpPracticeMethod.Implement
{
    public class ChatPipeLine
    {
        IChatSomething root;
        IChatSomething curent;

        public void Collect(Boolean hello, Boolean niceToMeetYou)
        {
            foreach (var say in GenerateChatContent(hello, niceToMeetYou))
            {
                if (root == null)
                {
                    root = say;
                    curent = say;
                }
                else
                {
                    curent.Next = say;
                    curent = say;
                }
            }
        }

        public void ReleaseAll()
        {
            Release(root);
        }

        public void Release(IChatSomething current)
        {
            current.Speak("Kewos");
            if (current.Next != null) Release(current.Next);
        }

        public IEnumerable<IChatSomething> GenerateChatContent(Boolean hello, Boolean niceToMeetYou)
        {
            yield return new SayHello();
            yield return new NiceToMeetYou();
        }
    }

    public interface IChatSomething
    {
        void Speak(string name);
        IChatSomething Next { set; get; }
    }

    public abstract class BasicChat : IChatSomething
    {
        public abstract void Speak(string name);

        public IChatSomething Next { get; set; }
    }


    public class SayHello : BasicChat
    {
        public override void Speak(string name)
        {
            Console.WriteLine("Hello {0}", name);
        }
    }

    public class NiceToMeetYou : BasicChat
    {
        public override void Speak(string name)
        {
            Console.WriteLine("Nice To Meet You {0}", name);
        }
    }
}
