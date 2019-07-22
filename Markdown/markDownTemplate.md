- [This is an H1](#This-is-an-H1)
  - [This is an H2](#This-is-an-H2)
          - [This is an H6](#This-is-an-H6)
- [一级标题](#%E4%B8%80%E7%BA%A7%E6%A0%87%E9%A2%98)
  - [二级标题](#%E4%BA%8C%E7%BA%A7%E6%A0%87%E9%A2%98)
  - [列表](#%E5%88%97%E8%A1%A8)
  - [引用](#%E5%BC%95%E7%94%A8)
  - [选择框](#%E9%80%89%E6%8B%A9%E6%A1%86)
  - [表格](#%E8%A1%A8%E6%A0%BC)
  - [引用网址](#%E5%BC%95%E7%94%A8%E7%BD%91%E5%9D%80)
  - [引用特定类型文本](#%E5%BC%95%E7%94%A8%E7%89%B9%E5%AE%9A%E7%B1%BB%E5%9E%8B%E6%96%87%E6%9C%AC)
  - [数学公式](#%E6%95%B0%E5%AD%A6%E5%85%AC%E5%BC%8F)
  - [转义字符，加 “\”](#%E8%BD%AC%E4%B9%89%E5%AD%97%E7%AC%A6%E5%8A%A0)
  - [图片](#%E5%9B%BE%E7%89%87)
    - [base64的图片转换 Python 代码](#base64%E7%9A%84%E5%9B%BE%E7%89%87%E8%BD%AC%E6%8D%A2-Python-%E4%BB%A3%E7%A0%81)
- [🎉Life is fantastic🥳!](#%F0%9F%8E%89Life-is-fantastic%F0%9F%A5%B3)



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

*这些文字显示为斜体*

**这些文字显示为粗体**

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
![Alt text](https://www.chiphell.com/static/image/common/logo.png "Optional title")

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

[Markdown语法说明（详解版）](http://www.ituring.com.cn/article/504)


# 🎉Life is fantastic🥳!


