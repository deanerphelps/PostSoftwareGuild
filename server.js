const Discord = require("discord.js");
const bot = new Discord.Client();
const token = "NjAzNjgwNDgxNzkxMzEyMDIx.XTi7nA.KXamXKKqZNacZEX0fI6HqiWk41w";
bot.on("ready", () => {
  console.log("Bot is online");
});

bot.on("message", msg => {
  if (msg.content === "meow") {
    msg.channel.send("MEOW");
  }
});
bot.login(token);
