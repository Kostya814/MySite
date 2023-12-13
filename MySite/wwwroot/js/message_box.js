let message_info = document.querySelector('.message_info');
let message_info_text = document.querySelector('.message_info p');
if (message_info_text.textContent !== '')
{
    message_info.style.visibility = 'visible';
    setTimeout(() => {
        message_info.style.visibility = 'hidden';
        message_info_text.textContent = '';
    }, 5000);
    
}

