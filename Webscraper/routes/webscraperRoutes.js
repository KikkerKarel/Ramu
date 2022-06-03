const express = require('express');
const webscrapercontroller = require('../controller/webscraperController');

const router = express.Router();

router
    .route('/scrape/banner')
    .get(webscrapercontroller.scrapeBanner);

router
    .route('/scrape/about')
    .post(webscrapercontroller.scrapeAbout);

module.exports = router;