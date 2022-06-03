const Webscraper = require('../model/webscraperModel');
const catchAsync = require('../utils/catchAsync');
const Scraper = require('../repository/webscraperRepo');

exports.scrapeBanner = catchAsync(async(req, res, next) => {

    newScraper = new Webscraper(req.body.url);

    var result = await Scraper.getBanner(newScraper);

    res.status(200).send({
        success: true,
        payload: result
    });
});

exports.scrapeAbout = catchAsync(async(req, res, next) => {

    newScraper = new Webscraper(req.body.url);

    var result = await Scraper.getAbout(newScraper);

    res.status(200).send({
        success: true,
        payload: result
    });
});