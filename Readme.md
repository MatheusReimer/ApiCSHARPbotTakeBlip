##  This is a project where I developed an API that requests from github API, filters the information the way I stabilished and send the updated information to a third party Chatbot API provided by TakeBlip that consumes that info ##

## The API is available at: https://webapichatbotdeployment.azurewebsites.net/api/Infos ##
<p>If you go to this page, you will get results like these. I highly recomend the use o postman to do so.</p>
<img src="https://user-images.githubusercontent.com/56495954/129281249-a5d1a572-7c9a-4a8a-a01c-3453a96ae81a.png"></img>


## The Instructions to consume the API are at: https://webapichatbotdeployment.azurewebsites.net/index.html ##
</br>
<p>The language that i've picked to develop this API is C# + .net Core(3.1). I also utilized frameworks and libraries like : Newtonsoft to handle the JSON files, Swagger to help document the API, and Swashbuckel which is a complement to Swagger.  </p>
<p>The deployment server is hosted by Azure.</p>


</br>
<h3>The main project flow since the start of the CHATBOT aplication goes like this:</h3>
</br>


</br>![Blank diagram](https://user-images.githubusercontent.com/56495954/129279053-7c302b91-faf1-4591-8796-76a50514fe80.png)


</br>

<p>The flow could go back up if the user requested another information but since the GET requests would be already processed in this case, essentialy there would be no reason to increment the flow schema.</p>



## Note ##

<p>I do realize that the way  I did to grab the processed information might not be the best way to do so. I could not find a way to implement multiples returns in the <a href="https://docs.blip.ai">docs</a> as I needed- 5 details, 5 titles and 5 images - My attempt was to return an array and just make 3 calls to my API but since the Chatbot cant handle array as arguments, I was not sure how to proceed. </p>




## Final BOT Structure ##
<p>The way that the bot was structured: </p>
</br>
<img src ="https://user-images.githubusercontent.com/56495954/129286102-691b8ac0-557e-402d-bd75-d3663fa3ec99.png"></img>
