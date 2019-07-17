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

## 转义字符
\*literal asterisks\*


## 图片
![Alt text](https://www.chiphell.com/static/image/common/logo.png "Optional title")

![](./logo.png)

![avatar](data:image/png;base64,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)

### base64的图片转换 Python 代码
```python
# 使用python将图片转化为base64字符串
import base64
f=open('723.png','rb') #二进制方式打开图文件
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