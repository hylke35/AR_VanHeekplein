// import libraries
var express = require('express');
var router = express.Router();
var js2xmlparser = require('js2xmlparser');
var xmlparser = require('express-xml-bodyparser');
var bodyParser = require('body-parser');
var dbConnect = require('./dbConnect.js');

// Login
router.post('/login', function (req, res) {
	console.log(req.body);
	let data = [
		req.body.Email
	];
	
	let sql = "SELECT * FROM user WHERE email = ?";
	let query = dbConnect.query(sql, data,(err, results) => {
		if(err) throw err;

		let response = {};
		if (results.length == 1) {
			if (results[0].password == req.body.Password) {
				response.code = 1;
				response.message = "Succesfully Logged In.";
			} else {
				response.code = 2;
				response.message = "Password is wrong.";
			}
		} else {
			response.code = 3;
			response.message = "E-Mail Adress does not exist.";
		}
		res.send(response);
	});
});

module.exports = router;