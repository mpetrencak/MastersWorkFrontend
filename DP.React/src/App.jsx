import React, { useCallback, useState } from 'react';
import { BlazorPage } from "./BlazorApp";

function App() {
  const [nextCounterIndex, setNextCounterIndex] = useState(1);
  const [blazorCounters, setBlazorCounters] = useState([]);
 
  const addBlazorCounter = () => {
    const index = nextCounterIndex;
    setNextCounterIndex(index + 1);
    
    setBlazorCounters(blazorCounters.concat([{
      title: `Counter ${index}`,
      incrementAmount: index,
      customObject: { StringValue: 'Hello!', IntegerValue: 42 },
    }]));
  };

  const modifyParameters = () => {
    setBlazorCounters(blazorCounters.map((counter) => {
      return {
        ...counter,
        incrementAmount: counter.incrementAmount + 1,
        customObject: {
          StringValue: counter.customObject.StringValue + '!',
          IntegerValue: counter.customObject.IntegerValue - 1,
        }
      };
    }));
  };

  const removeBlazorCounter = () => {
    setBlazorCounters(blazorCounters.slice(0, -1));
  };

  const logEventArgs = useCallback((eventArgs) => {
    console.log(eventArgs);
  }, []);

  var cssBootstrap = 'bootstrap.min.css';
  if (!document.getElementById(cssBootstrap)) {
      var head = document.getElementsByTagName('head')[0];
      var link = document.createElement('link');
      link.id = cssBootstrap;
      link.rel = 'stylesheet';
      link.type = 'text/css';
      link.href = '/css/bootstrap/bootstrap.min.css';
      link.media = 'all';
      head.appendChild(link);
  }

  var cssBootstrapDark = 'bootstrap-dark.min.css';
  if (!document.getElementById(cssBootstrapDark)) {
      var head = document.getElementsByTagName('head')[0];
      var link = document.createElement('link');
      link.id = cssBootstrapDark;
      link.rel = 'stylesheet';
      link.type = 'text/css';
      link.href = '/css/bootstrap/bootstrap-dark.min.css';
      link.media = 'all';
      head.appendChild(link);
  }

  var cssBootstrapToggle = 'toggle-bootstrap.min.css';
  if (!document.getElementById(cssBootstrapToggle)) {
      var head = document.getElementsByTagName('head')[0];
      var link = document.createElement('link');
      link.id = cssBootstrapToggle;
      link.rel = 'stylesheet';
      link.type = 'text/css';
      link.href = '/css/bootstrap/toggle-bootstrap.min.css';
      link.media = 'all';
      head.appendChild(link);
  }

  var cssBootstrapToggleDark = 'toggle-bootstrap-dark.min.css';
  if (!document.getElementById(cssBootstrapToggleDark)) {
      var head = document.getElementsByTagName('head')[0];
      var link = document.createElement('link');
      link.id = cssBootstrapToggleDark;
      link.rel = 'stylesheet';
      link.type = 'text/css';
      link.href = '/css/bootstrap/toggle-bootstrap-dark.min.css';
      link.media = 'all';
      head.appendChild(link);
  }

  var cssApp = 'app.css';
  if (!document.getElementById(cssApp)) {
      var head = document.getElementsByTagName('head')[0];
      var link = document.createElement('link');
      link.id = cssApp;
      link.rel = 'stylesheet';
      link.type = 'text/css';
      link.href = '/css/app.css';
      link.media = 'all';
      head.appendChild(link);
  }

  var cssFas= 'font-awesome-all.css';
  if (!document.getElementById(cssFas)) {
      var head = document.getElementsByTagName('head')[0];
      var link = document.createElement('link');
      link.id = cssFas;
      link.rel = 'stylesheet';
      link.type = 'text/css';
      link.href = '/lib/font-awesome/css/all.css';
      link.media = 'all';
      head.appendChild(link);
  }
  

  
  return (
    <div className="App">
      <h1 className="title">Blazor in React app</h1>

      {blazorCounters.map(counter =>
          <div key={counter.title}>
            <BlazorPage
              title={counter.title}
              incrementAmount={counter.incrementAmount}
              customObject={counter.customObject}
              customCallback={logEventArgs}>
            </BlazorPage>
          </div>
        )}

 
      <div id="app"></div>
    </div>
  );
}

export default App;
