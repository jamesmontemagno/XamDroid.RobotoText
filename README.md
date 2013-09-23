

XamDroid.RobotoText
================

Implementation backwards compatibility Roboto font in any control!.

Read the blog posts:
[RobotTextView](http://motzcod.es/post/61775933477/beautiful-android-compat-roboto-fonts-in)
[RobotoTextFactory](http://motzcod.es/post//super-roboto-fonts-custom-layoutinflater-ifactory-in)


## Demo

![Sample](https://raw.github.com/jamesmontemagno/XamDroid.RobotoText/master/Screenshots/Sample.png)
![Factory](https://raw.github.com/jamesmontemagno/XamDroid.RobotoText/master/Screenshots/Factory.JPG)

## Getting started

### Installing the library
Add library to your project or clone it and do the following:
* Add all fonts into Asses/fonts and ensure they are marked as `AndroidAsset` as the build action
* Add RobotoTextView and feel free to change the namespace
* Add the custom attributes in the attrs.xml in your Resources/Values folder.

### Usage
In any layout that you wish to use the Roboto Font simply include a new `xmlns`

```
xmlns:local="http://schemas.android.com/apk/res-auto"
```

Then create a new RobotoTextView
```
<com.refractored.controls.RobotoTextView
          android:layout_width="fill_parent"
          android:layout_height="wrap_content"
          local:typeface="roboto_thin"
          android:text="Roboto Thin"
          android:textAppearance="?android:attr/textAppearanceMedium" />
```

The most important part is: `local:typeface`

Valid options are:
* roboto_thin
* roboto_thin_italic
* roboto_light
* roboto_light_italic
* roboto_regular
* roboto_medium
* roboto_medium_italic
* roboto_bold
* roboto_bold_italic
* roboto_black
* roboto_black_italic
* roboto_condensed
* roboto_condensed_italic
* roboto_condensed_bold
* roboto_condensed_bold_italic

### Expanding
You can apply this same concept to any other control such as a CheckedTextView.

### Expand with custom LayoutInflator Factory
Also included is `RobotoTextFactory`. If you want you will still need the `typeface` enum attribute but this will allow you to add the typeface to any View that derives from TextView such as Button, CheckBox, etc. All you will need to do is set the RobotoTextFactory before SetContentView is called:

```
protected override void OnCreate(Bundle bundle)
{
    base.OnCreate(bundle);
    LayoutInflater.Factory = new RobotoTextFactory();
    // Set our view from the "main" layout resource
    this.SetContentView(Resource.Layout.Main);
}
```

In your axml file all you need to do is add the custom attribute onto any of your Views:

```
<CheckBox
     android:layout_width="fill_parent"
     android:layout_height="wrap_content"
     android:text="CheckBox with Roboto Thin"
     local:typeface="roboto_thin" />
```

This will result in something like this:
![Factory](https://raw.github.com/jamesmontemagno/XamDroid.RobotoText/master/Screenshots/Factory.JPG)


## Development:

Ported and Maintained by:
James Montemagno ([@JamesMontemagno](http://www.twitter.com/jamesmontemagno))

Original Concept on ([Stack Overflow](http://stackoverflow.com/questions/4395309/android-want-to-set-custom-fonts-for-whole-application-not-runtime/9199258#9199258))


## License

    Copyright 2013 James Montemagno

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.
