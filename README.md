# MvvmLight_WPF_Frame_Nav
## Purpose
The purpose is to create a template or example program that can be used as a staring point for a WPF C# Navigation program using MVVMLight toolkit and a Frame Control. The frame will navigate between several pages and the program will incorporate features of MVVMLight.  

## Goals
1. Use MVVMLight
2. Use a Frame Control
3. Pass a class/object between pages and allow updates from any page and other pages will show updated info.
4. Incorporate services:  NavigationService, DialogueService, and DataService
5. Use SimpleIOC
6. Use RelayCommand along with CanExecute
7. Use Messanger if needed (depends on how passing object between pages). 
8. Have a Blendable design time experience Laurent so talks about...

## Issues
1. RelayCommand CanExecute for Button does not seem to work for following code: 
```
        private RelayCommand _changeToLastPage;

        /// <summary>
        /// Gets the ChangeToLastPage.
        /// </summary>
        public RelayCommand ChangeToLastPage
        {
            get
            {
                return _changeToLastPage
                    ?? (_changeToLastPage = new RelayCommand(
                    () =>
                    {
                        FrameUri = ViewModelLocator.LastPageUri;                       
                    },
                () => FrameUri != ViewModelLocator.LastPageUri));                
            }
        }
```
At least it doesn't have the behavior I would like which is to DISABLE the button when the page commanded by the button is displayed in the Frame Control.  I tried replacing that expression with an integer and value for the page and it didn't work either (IE page1 = 1, Page2 = 2, etc).  It seems like a very easy thing to do, but not working like I would expect.  Also, I simply changed the expression to FALSE and the button is disabled and grayed out.  Not sure why my expression isn't working.  Tried two different versions of the RelayCommand and neither worked like I thought it would.  It seems like the INotifyPropertyChanged isn't working for me for some reason?

2. The frame has a navigationService Property associated with it and I tried to copy Laurent's navigation class example from a WindowsPhone example and one line of code doesn't seem to be working like it should, at least I can't get it to work.  From Laurent's NavigationService example [here](http://blog.galasoft.ch/posts/2011/01/navigation-in-a-wp7-application-with-mvvm-light/).  The following line needs to be changed:
```
_mainFrame = Application.Current.RootVisual as PhoneApplicationFrame;  
```
I tried changing it to with help from [stackoverflow](https://stackoverflow.com/questions/2216917/wpf-equivalent-to-silverlight-rootvisual) but _mainFrame is alwyas NULL: 
```
_mainFrame = LogicalTreeHelper.FindLogicalNode(Application.Current.MainWindow, "MainFrameDS") as Frame;
```
But didn't work, nor did this:
```
 _mainFrame = Application.Current.MainWindow.FindName("MainFrameDS") as Frame;
```
3. DESIGN TIME: I do not get the page to display in the frame in the mainwindow.xaml during design time.  not sure if it's an itemtemplate I need or some sort of static implementation for design time.  Laurent talked briefly about this in the pluralsite video, but it's buried somewhere and need to watch the video again.

4. Haven't gotten to it, but I need to be able to update my data class in one page and have the changes displayed in the next pages.  I need to pass it from page to page.
