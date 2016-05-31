using System;
using System.Collections.Generic;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class ChatPipeLine
    {
        private IChatSomething curent;
        private IChatSomething root;

        public void Collect(bool hello, bool niceToMeetYou)
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

        public IEnumerable<IChatSomething> GenerateChatContent(bool hello, bool niceToMeetYou)
        {
            yield return new SayHello();
            yield return new NiceToMeetYou();
        }
    }

    public interface IChatSomething
    {
        IChatSomething Next { set; get; }
        void Speak(string name);
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