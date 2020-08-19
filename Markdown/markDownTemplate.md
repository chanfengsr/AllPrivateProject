- [This is an H1](#this-is-an-h1)
  - [This is an H2](#this-is-an-h2)
          - [This is an H6](#this-is-an-h6)
- [一级标题](#一级标题)
  - [二级标题](#二级标题)
  - [列表](#列表)
  - [引用](#引用)
  - [选择框](#选择框)
  - [表格](#表格)
  - [引用网址](#引用网址)
  - [引用特定类型文本](#引用特定类型文本)
  - [数学公式](#数学公式)
  - [转义字符，加 “\”](#转义字符加-)
  - [图片](#图片)
    - [base64的图片转换 Python 代码](#base64的图片转换-python-代码)
    - [base64的图片转换 HTML5 代码](#base64的图片转换-html5-代码)
  - [字体颜色](#字体颜色)
    - [🌷斑马复古五色代码：](#斑马复古五色代码)
    - [🌷斑马荧光笔暗五色代码：](#斑马荧光笔暗五色代码)
    - [🌷斑马荧光笔柔五色代码：](#斑马荧光笔柔五色代码)
    - [🌷斑马荧光笔荧光五色代码：](#斑马荧光笔荧光五色代码)
- [🎉Life is fantastic🥳!](#life-is-fantastic)



# This is an H1
## This is an H2
###### This is an H6

一级标题
===========
二级标题
---------------------

## 列表
*   Red
*   Green
*   Blue

## 引用
> ## This is a header.
> 
> 1.   This is the first list item.
> 2.   This is the second list item.
> 
>> Here's some example code:
> 
>     return shell_exec("echo $input | $markdown_script");

单个回车
视为空格。

连续回车

才能分段。

行尾加两个空格，这里->  
即可段内换行。

ctrl + b  
**这些文字显示为粗体**

ctrl + i  
*这些文字显示为斜体*
  
~~*这些文字删除线*~~

分割线
***

## 选择框
> alt + c to Check
- [ ] todo1 
- [x] todo2

## 表格
 | Left | Center | Right |
 | :--- | :----- | :---- |
 | 1    | 2      | 3     |
 | 45   | 67     | 89    |

## 引用网址

This is [an example](http://example.com/ "Title") inline link.  
[This link](http://example.net/) has no title attribute.  
This is [an example][id] reference-style link.

[id]: http://example.com/  "Optional Title Here"

## 引用特定类型文本
```
<div>   
    <div></div>
    <div></div>
    <div></div>
</div>
```

```javascript
var num = 0;
for (var i = 0; i < 5; i++) {
    num+=i;
}
console.log(num);
```


## 数学公式
$$
f(x) = \int_{-\infty}^\infty
   \hat f(\xi)\,e^{2 \pi i \xi x}
   \,d\xi
$$

## 转义字符，加 “\”
\*literal asterisks\*


## 图片
![Alt text](https://raw.githubusercontent.com/chanfengsr/AllPrivateProject/master/Markdown/logo.png "Optional title")

![](./logo.png)

![avatar](data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQBAMAAADt3eJSAAAALVBMVEXM3fm+1Pfb5/rF2fjw9f23z/aavPOhwfTp8PyTt/L3+v7T4vqMs/K7zP////+qRWzhAAAAXElEQVQIW2O4CwUM996BwVskxtOqd++2rwMyPI+ve31GD8h4Madqz2mwms5jZ/aBGS/mHIDoen3m+DowY8/hOVUgxusz+zqPg7SvPA1UxQfSvu/du0YUK2AMmDMA5H1qhVX33T8AAAAASUVORK5CYII=)

### base64的图片转换 Python 代码
```python
# 使用python将图片转化为base64字符串
import base64
f=open('a.png','rb') #二进制方式打开图文件
ls_f=base64.b64encode(f.read()) #读取文件内容，转换为base64编码
f.close()
print(ls_f)


# base64字符串转化为图片
import base64
bs='iVBORw0KGgoAAAANSUhEUg....' # 太长了省略
imgdata=base64.b64decode(bs)
file=open('2.jpg','wb')
file.write(imgdata)
file.close()
```

### base64的图片转换 HTML5 代码
```html
<!Doctype html>
<html>

<head>
    <meta charset="utf-8" />
    <title>html5 image to base64</title>
</head>

<body>
    <script type="text/javascript">
        window.onload = function () {
            // 抓取上传图片，转换代码结果，显示图片的dom
            var img_upload = document.getElementById("img_upload");
            var base64_code = document.getElementById("base64_code");
            var img_area = document.getElementById("img_area");
            // 添加功能出发监听事件
            img_upload.addEventListener('change', readFile, false);
        }
        function readFile() {
            var file = this.files[0];
            if (!/image\/\w+/.test(file.type)) {
                alert("请确保文件为图像类型");
                return false;
            }
            var reader = new FileReader();
            reader.readAsDataURL(file);
            reader.onload = function () {
                base64_code.innerHTML = this.result;
                img_area.innerHTML = '<div>图片img标签展示：</div><img src="' + this.result + '" alt=""/>';
            }
        }
    </script>
    <input type="file" id="img_upload" />
    <textarea id="base64_code" rows="30" cols="360"></textarea>
    <p id="img_area"></p>
</body>

</html>
```


## 字体颜色
$\color{red}{红色字}$
$\color{#FF0000}{红色字}$
$\color{rgb(255,255,0)}{黄色字}$

$\color{#4285f4}{更}\color{#ea4335}{丰}\color{#fbbc05}{富}\color{#4285f4}{的}\color{#34a853}{颜}\color{#ea4335}{色}$
$\color{#4285f4}{G}\color{#ea4335}{o}\color{#fbbc05}{o}\color{#4285f4}{g}\color{#34a853}{l}\color{#ea4335}{e}$


### 🌷斑马复古五色代码：
<font color=#214490 size=12 face="黑体">★☻⚑</font>
<font color=#66A0BB size=12 face="黑体">★☻⚑</font>
<font color=#27613C size=12 face="黑体">★☻⚑</font>
<font color=#9A322D size=12 face="黑体">★☻⚑</font>
<font color=#733C2A size=12 face="黑体">★☻⚑</font>

### 🌷斑马荧光笔暗五色代码：
<font color=#ACCACC size=12 face="黑体">★☻⚑</font>
<font color=#C076C1 size=12 face="黑体">★☻⚑</font>
<font color=#E3A598 size=12 face="黑体">★☻⚑</font>
<font color=#9D8487 size=12 face="黑体">★☻⚑</font>
<font color=#EAD36D size=12 face="黑体">★☻⚑</font>

### 🌷斑马荧光笔柔五色代码：
<font color=#D78E9F size=12 face="黑体">★☻⚑</font>
<font color=#A69FC9 size=12 face="黑体">★☻⚑</font>
<font color=#918D8C size=12 face="黑体">★☻⚑</font>
<font color=#8B91AB size=12 face="黑体">★☻⚑</font>
<font color=#C5D5B0 size=12 face="黑体">★☻⚑</font>

### 🌷斑马荧光笔荧光五色代码：
<font color=#5CC5C8 size=12 face="黑体">★☻⚑</font>
<font color=#F8C79C size=12 face="黑体">★☻⚑</font>
<font color=#FCF1C7 size=12 face="黑体">★☻⚑</font>
<font color=#7CBDE7 size=12 face="黑体">★☻⚑</font>
<font color=#FDA1B6 size=12 face="黑体">★☻⚑</font>





[Markdown语法说明（详解版）](http://www.ituring.com.cn/article/504)



# 🎉Life is fantastic🥳!


