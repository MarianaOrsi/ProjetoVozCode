// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const SpeechRecognition =
window.SpeechRecognition || window.webkitSpeechRecognition;

const SpeechRecognitionEvent =
window.SpeechRecognitionEvent || window.webkitSpeechRecognitionEvent;


const recognition = new SpeechRecognition();
recognition.continuous = false;
recognition.lang = "pt-BR";
recognition.interimResults = false;
recognition.maxAlternatives = 1;