using Android.Speech.Tts;
using Xamarin.Forms;
using Lab07.Droid;


[assembly: Dependency(typeof(TextToSpeechImplementation))]
namespace Lab07.Droid

{
    public class TextToSpeechImplementation : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        TextToSpeech speaker;
        string toSpeak;
        public void Speak(string text)
        {
            toSpeak = text;
            if (speaker == null)
            {

#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                speaker = new TextToSpeech(context: Forms.Context, listener: this);
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
            }
            else
            {
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
            }
        }

        #region IOnInitListener implementation
        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
            }
        }
        #endregion
    }
}