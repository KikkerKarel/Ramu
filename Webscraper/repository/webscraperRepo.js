const { default: axios } = require("axios")
const cheer = require('cheerio');

const imageUrl ="https://i.scdn.co/image/ab6761610000e5ebbf973f439e9a11dab997893c";

exports.getBanner = async (url) => {
    axios.get("https://open.spotify.com/artist/5V1qsQHdXNm4ZEZHWvFnqQ")
        .then(function(html) {
            var $ = cheer.load(html.data);
            // console.log($('div').append('<div class="Type__TypeElement-goli3j-0 fCtMzo CjnwbSTpODW56Gerg7X6" dir="auto"></div>'));
            // var idk = [];

            // $('div').each(function(){
            //     if ($(this).attr('style') == undefined)
            //     {

            //     } else {
            //         idk.push($(this).attr('style'));
            //     }
            // });
        })
        .catch(function(err){
            console.log(err);
        });

}

exports.getAbout = async (url) => {
    const result = await axios.get(`${url.url}`);
    var $ = cheer.load(result.data);
    var list = [];
    $('div').append('<div class="Type__TypeElement-goli3j-0 fCtMzo CjnwbSTpODW56Gerg7X6" dir="auto"></div>').each(function(index, element){
        list.push($(this).text());
    });
    return list[0].split('monthly listeners')[2];
}