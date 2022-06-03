const express = require('express');
const cors = require('cors');

const scraper = require('./routes/webscraperRoutes');

const app = express();

app.use(cors());
app.use(express.json());

app.use('/webscraper', scraper);

module.exports = app;