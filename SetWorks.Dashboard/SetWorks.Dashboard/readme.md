
Quick & Dirty MVP
Simple, get the core stuff using HttpClient calls to get data and populate the UI.
(Check in)

Prettier MVP
Add some v2 features and make it look a little prettier.  
Make sure that it is accessible.  
(Check in)

EF Core MVP
Plug in the EF Core functionality, ya wanna get hired don't you?
(Check in)

Thoughts MVP
Write up a short manifesto about all of this.  


Notes
Not sure where shared classes, etc., work for Domain Driven Design.  I have fear that DDD just abstracts things out 10 layers.  

Add an API layer to manage state and data.  Use gRPC for this, lol.

_Layout.cshtml has two links to third party hosted CSS files.  NEVER do this in real life.

? How to ensure that accessibility features are part of the components?  Did MSFT or Blazorise build them in?

bug - User can select ALL along with other states.  


Assignment
Scope - Your web application should:
* Display a Grid / Table of Cases of Covid by State.
* Display the Date, State, Total, Positive, Negative, and Hospitalization Rates as columns.
* Provide a Date Filter to be able to change the Date of the Data displayed.
* Provide a State Filter to be able to filter on specific States.
* By Default - Order the States by the States that have the highest Positive Covid Rates
in Descending Order.
Optional / Extra Credit
* Feel free to expand and build out any other features to showcase your skills (such as a
Map or whatever you want to show us).
* Feel free to show us your design / architecture skills (separate of concerns) as well.
* Feel free to write Unit/Integrate Tests as well, to show us you know how to do this.


