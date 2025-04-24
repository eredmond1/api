using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto{
                ID = commentModel.ID,
                StockID = commentModel.StockID,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn, 
            };
        }

        public static Comment ToCommentFromCreateDTO(this CreateCommentDto commentDto, int stockId)
        {
            return new Comment 
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                StockID = stockId,

            };
        }

        public static Comment ToCommentFromUpdateDTO(this UpdateCommentRequestDto updateDto)
        {
            return new Comment{
                Title= updateDto.Title,
                Content= updateDto.Content
            };
        }
    }
}