import React,{Component} from 'react';
class Login extends Component {
    render () {
      return (
        
        <div>

          
          <div className={'page-container'}>

        </div>
          

          <div class="content">
  <div class="head">
    <h1>Apartment Management System</h1>
  </div>
  <div class="inputs">
    <input type="email" placeholder="Email"/><br/>
    <input type="password" placeholder="password"/><br/>
    <input type="submit" value="Login"/>
  </div>
</div>
      
        </div>
      )
    }
  }
  

// function  componentDidMount() {
//     // Simple POST request with a JSON body using fetch
//     const requestOptions = {
//         method: 'POST',
//         headers: { 'Content-Type': 'application/json' },
//         body: JSON.stringify({ Email: 'shrcvk@gmail.com' , Password : "1111" })
//     };
//     fetch('https://reqres.in/api/posts', requestOptions)
//         .then(response => response.json())
//         .then(data => this.setState({ postId: data.id }));
// }
  
  export default Login